﻿namespace AFS.SAMPLE.Helper.Domain;

public class DomainEventRecord
{
    public string Type { get; set; }
    public List<KeyValuePair<string, string>> Args { get; set; }
    public string CorrelationID { get; set; }
    public DateTime Created { get; set; }
}
