// <auto-generated />
using JobOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobOffer.Migrations
{
    [DbContext(typeof(JobOfferContext))]
    [Migration("20211108075815_AddUserAplication")]
    partial class AddUserAplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobOffer.Models.JobOfferModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CreatorId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("JobOffer.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobOffer.Models.UserApplication", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("UserId");

                    b.ToTable("UserApplications");
                });

            modelBuilder.Entity("JobOffer.Models.JobOfferModel", b =>
                {
                    b.HasOne("JobOffer.Models.User", "Creator")
                        .WithMany("JobOffers")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("JobOffer.Models.UserApplication", b =>
                {
                    b.HasOne("JobOffer.Models.JobOfferModel", "JobOffer")
                        .WithMany("UserApplications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobOffer.Models.User", "User")
                        .WithMany("UserApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobOffer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobOffer.Models.JobOfferModel", b =>
                {
                    b.Navigation("UserApplications");
                });

            modelBuilder.Entity("JobOffer.Models.User", b =>
                {
                    b.Navigation("JobOffers");

                    b.Navigation("UserApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
