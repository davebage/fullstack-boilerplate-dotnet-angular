using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class TransactionRequest
{
    [Required]
    public Guid account_id { get; set; }
    [Required]
    public int amount { get; set; }
}