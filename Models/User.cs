﻿
using System.ComponentModel.DataAnnotations;
public class User
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}

