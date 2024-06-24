﻿namespace Restaurants.Clean.Infrastructure;

public class BlobStorageSettings
{
    public string ConnectionString { get; set; } =default!;
    public string LogosContainerName { get; set; }=default!;
    public string AccountName { get; set; } = default!;
    public string AccountKey { get; set; } = default!;

}
