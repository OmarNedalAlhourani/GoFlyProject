using GoFly.BL.Models.BlogPage;
using GoFly.BL.Models.CarPage;
using GoFly.BL.Models.ContactPage;
using GoFly.BL.Models.FlightsPage;
using GoFly.BL.Models.HomePage;
using GoFly.BL.Models.HotelPage;
using GoFly.BL.Models.Search;
using GoFly.BL.Models.vacationPage;
using GoFly.BL.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoFly.EF.Data
{
    public class AppDbContext : IdentityDbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            
        }

        // Define your DbSet properties here.



        public DbSet<HotTour> HotTours { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PopularDestination> PopularDestinations { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<HostelDestination> HostelDestinations { get; set; }

        public DbSet<TravelBooking> TravelBookings { get; set; }
        public DbSet<CarRent> CarRents { get; set; }
        public DbSet<TouristSpots> TouristSpotes { get; set; }
        public DbSet<OurAddress> OurAddresses { get; set; }

        public DbSet<OurBlog> OurBlogs { get; set; }
        public DbSet<TodayFlight> TodayFlights { get; set; }
        public DbSet<Deal> Deals { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<SearchFlight> SearchFlights { get; set; }
        public DbSet<SearchHotel> SearchHotels { get; set; }
        public DbSet<SearchPackage> SearchPackages { get; set; }

    }
}
