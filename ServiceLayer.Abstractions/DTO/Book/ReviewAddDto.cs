﻿namespace ServiceLayer.Abstractions.DTO
{
    public class ReviewAddDto
    {
        public string VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }

        public int BookId { get; set; }

        public ReviewAddDto()
        {

        }
    }
}
