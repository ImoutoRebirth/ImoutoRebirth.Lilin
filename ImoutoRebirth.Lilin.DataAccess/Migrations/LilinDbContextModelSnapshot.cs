﻿// <auto-generated />
using System;
using ImoutoRebirth.Lilin.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ImoutoRebirth.Lilin.DataAccess.Migrations
{
    [DbContext(typeof(LilinDbContext))]
    partial class LilinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.FileTagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Source")
                        .HasColumnType("integer");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

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
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PositionFromLeft")
                        .HasColumnType("integer");

                    b.Property<int>("PositionFromTop")
                        .HasColumnType("integer");

                    b.Property<int>("Source")
                        .HasColumnType("integer");

                    b.Property<int?>("SourceId")
                        .HasColumnType("integer");

                    b.Property<int>("Width")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<bool>("HasValue")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Synonyms")
                        .HasColumnType("text");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("TypeId", "Name")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ImoutoRebirth.Lilin.DataAccess.Entities.TagTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Color")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

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
