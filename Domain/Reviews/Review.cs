using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Domain.Reviews;

public sealed class Review : Entity
{
    private Review(
        Guid guid,
        Guid apartamentId,
        Guid bookingId,
        Guid userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
        : base(id)
    {
        ApartmentId = apartamentId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    private Review()
    {
        
    }

    public Guid ApartmentId { get; set; }
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public Rating Rating { get; set; }
    public Comment Comment { get; set; }
    public DateTime CreatedOnUtc { get; set; }

    public static Results<Review> Create(
        Rating rating,
        Comment comment,
        DateTime cretedOnUtc)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            return Results.Failure<Review>(ReviewErrors.NotEligible)
        }

        var review = new Review(
            Guid.NewGuid(),
            booking.Apartament,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            createdOnUtc);
        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));
        return review;
    }
}