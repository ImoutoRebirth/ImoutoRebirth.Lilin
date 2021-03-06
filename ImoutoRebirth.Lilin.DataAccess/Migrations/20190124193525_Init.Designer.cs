﻿// <auto-generated />
using System;
using ImoutoRebirth.Lilin.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ImoutoRebirth.Lilin.DataAccess.Migrations
{
    [DbContext(typeof(LilinDbContext))]
    [Migration("20190124193525_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.FileTagEntity", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTimeOffset>("AddedOn");

                    b.Property<Guid>("FileId");

                    b.Property<DateTimeOffset>("ModifiedOn");

                    b.Property<int>("Source");

                    b.Property<Guid>("TagId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("TagId");

                    b.HasIndex("Source", "TagId");

                    b.HasIndex("TagId", "Value");

                    b.HasIndex("FileId", "TagId", "Source");

                    b.ToTable("FileTags");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.NoteEntity", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTimeOffset>("AddedOn");

                    b.Property<Guid>("FileId");

                    b.Property<int>("Height");

                    b.Property<string>("Label")
                        .IsRequired();

                    b.Property<DateTimeOffset>("ModifiedOn");

                    b.Property<int>("PositionFromLeft");

                    b.Property<int>("PositionFromTop");

                    b.Property<int>("Source");

                    b.Property<int?>("SourceId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTimeOffset>("AddedOn");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<bool>("HasValue");

                    b.Property<DateTimeOffset>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Synonyms");

                    b.Property<Guid>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("TypeId", "Name")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.TagTypeEntity", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<DateTimeOffset>("AddedOn");

                    b.Property<int>("Color");

                    b.Property<DateTimeOffset>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TagTypes");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.FileTagEntity", b =>
                {
                    b.HasOne("ImoutoRebirth.Lilin.DataAccess.Entities.TagEntity", "Tag")
                        .WithMany("FileTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.TagEntity", b =>
                {
                    b.HasOne("ImoutoRebirth.Lilin.DataAccess.Entities.TagTypeEntity", "Type")
                        .WithMany("Tags")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
