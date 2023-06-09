﻿namespace StatusCodes.API.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public int PlatformCode { get; set; }
        public int Code { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Platform { get; set; }
    }
}
