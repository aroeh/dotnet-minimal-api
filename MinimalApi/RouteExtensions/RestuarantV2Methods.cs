﻿using Microsoft.AspNetCore.Mvc;
using MinimalApi.Models;
using MinimalApi.Repos;

namespace MinimalApi.RouteExtensions
{
    public static class RestuarantV2Methods
    {
        public static async Task<IResult> GetAll(IRestuarantRepo restuarantRepo)
        {
            List<Restuarant> restuarants = await restuarantRepo.GetAllRestuarants();

            if (restuarants == null || restuarants.Count == 0)
            {
                return Results.NotFound();
            }
            return Results.Ok(restuarants);
        }

        public static async Task<IResult> Find(IRestuarantRepo restuarantRepo, [FromBody] SearchCriteria search)
        {
            List<Restuarant> restuarants = await restuarantRepo.FindRestuarants(search.Name, search.Cuisine);

            if (restuarants == null || restuarants.Count == 0)
            {
                return Results.NotFound();
            }
            return Results.Ok(restuarants);
        }

        public static async Task<IResult> GetById(IRestuarantRepo restuarantRepo, string id)
        {
            Restuarant restuarant = await restuarantRepo.GetRestuarant(id);

            if (restuarant == null || string.IsNullOrWhiteSpace(restuarant.Id))
            {
                return Results.NotFound();
            }

            return Results.Ok(restuarant);
        }

        public static async Task<IResult> AddRestuarant(IRestuarantRepo restuarantRepo, [FromBody] Restuarant restuarant)
        {
            bool success = await restuarantRepo.InsertRestuarant(restuarant);
            return Results.Ok(success);
        }

        public static async Task<IResult> UpdateRestuarant(IRestuarantRepo restuarantRepo, [FromBody] Restuarant restuarant)
        {
            bool success = await restuarantRepo.UpdateRestuarant(restuarant);
            return Results.Ok(success);
        }
    }
}