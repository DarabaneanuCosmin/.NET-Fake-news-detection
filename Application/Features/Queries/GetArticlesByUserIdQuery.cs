﻿using System;

namespace WebAPI.Features.Queries
{
    public class GetArticlesByUserIdQuery
    {
        public Guid Id_user { get; set; }

        public GetArticlesByUserIdQuery(Guid id)
        {
            Id_user = id;
        }

    }
}