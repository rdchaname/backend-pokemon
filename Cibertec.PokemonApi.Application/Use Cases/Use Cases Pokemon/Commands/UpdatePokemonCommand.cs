﻿using Cibertec.PokemonApi.Domain;
using MediatR;

namespace Cibertec.PokemonApi.Application.Use_Cases.Use_Cases_Pokemon.Commands
{
    public class UpdatePokemonCommand : IRequest
    {
        public Pokemon pokemon { get; set; }
    }
}