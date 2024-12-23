using AutoMapper;
using Cibertec.PokemonApi.Application.Common;
using Cibertec.PokemonApi.Domain.Repositories;
using Cibertec.PokemonApi.Domain.Servicios;
using MediatR;

namespace Cibertec.PokemonApi.Application.Casos_de_Uso.AdministrarUsuarios.RealizarLogin
{
    public class RealizarLoginHandler(IUsuarioRepository _usuarioRepository, IMapper _mapper, ITokenService service) : IRequestHandler<RealizarLoginRequest, IResult>
    {
        public async Task<IResult> Handle(RealizarLoginRequest request, CancellationToken cancellationToken)
        {
            IResult result = null;
            try
            {
                var validador = new RealizarLoginValidator();
                var validacionDatos = validador.Validate(request);

                if (!validacionDatos.IsValid) throw new ValidationException(validacionDatos.ToString(";"));

                var usuario = await _usuarioRepository.ConsultarByLoginPassword(request.Login, request.Password);

                if (usuario != null)
                {

                    var loginResponse = _mapper.Map<RealizarLoginResponse>(usuario);
                    loginResponse.Token = service.CreateToken(usuario);
                    result = new SuccessResult<RealizarLoginResponse>(loginResponse);
                }
                else
                {
                    throw new ValidationException("Usuario o contraseña incorrecta");
                }

            }
            catch (ValidationException ex)
            {

                result = new FailureResult<ValidationException>(ex.Message);
            }
            catch (Common.ApplicationException ex)
            {
                result = new FailureResult<Common.ApplicationException>(ex.Message);

            }
            catch (Exception ex)
            {

                result = new FailureResult<Exception>(ex.Message);
            }

            return result;

        }
    }
}
