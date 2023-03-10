// <auto-generated />
using System;
using MT4Hofer.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MT4Hofer.Migrations
{
    [DbContext(typeof(MeinContext))]
    partial class MeinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MT4Hofer.models.Klassenbucheintrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("SchuelerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SchuelerId");

                    b.ToTable("Klassenbucheintraege");
                });

            modelBuilder.Entity("MT4Hofer.models.Schueler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchulklasseId")
                        .HasColumnType("int");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SchulklasseId");

                    b.ToTable("Schueler");
                });

            modelBuilder.Entity("MT4Hofer.models.Schulklasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ErstelltDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Namen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schulklassen");
                });

            modelBuilder.Entity("MT4Hofer.models.Klassenbucheintrag", b =>
                {
                    b.HasOne("MT4Hofer.models.Schueler", "Schueler")
                        .WithMany("KlassenbucheintragListe")
                        .HasForeignKey("SchuelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schueler");
                });

            modelBuilder.Entity("MT4Hofer.models.Schueler", b =>
                {
                    b.HasOne("MT4Hofer.models.Schulklasse", "Schulklasse")
                        .WithMany("SchuelerListe")
                        .HasForeignKey("SchulklasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schulklasse");
                });

            modelBuilder.Entity("MT4Hofer.models.Schueler", b =>
                {
                    b.Navigation("KlassenbucheintragListe");
                });

            modelBuilder.Entity("MT4Hofer.models.Schulklasse", b =>
                {
                    b.Navigation("SchuelerListe");
                });
#pragma warning restore 612, 618
        }
    }
}
