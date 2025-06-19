using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Domain.Reviews;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

    private Rating(int value) => Value = value;

    public int Value { get; set; }

    public static Results<Rating> Create(int value)
    {
        if (value<1||value>5)
        {
            return Results.Failure<Rating>(Invalid);
        }

        return new Rating(value);
    }
}
