using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data;

namespace IIT360_api.Models
{
    public partial class iit360Context : DbContext
    {
        public iit360Context()
        {
        }

        public iit360Context(DbContextOptions<iit360Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Academic> Academic { get; set; }
        public virtual DbSet<AcademicDocument> AcademicDocument { get; set; }
        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<Ano> Ano { get; set; }
        public virtual DbSet<Cr> Cr { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventImage> EventImage { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<FacultyPublication> FacultyPublication { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Iitian> Iitian { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<ProjectScholarship> ProjectScholarship { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<PublicationDocument> PublicationDocument { get; set; }
        public virtual DbSet<Research> Research { get; set; }
        public virtual DbSet<Researcharea> Researcharea { get; set; }
        public virtual DbSet<Routine> Routine { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("", x => x.ServerVersion("10.2.10-mariadb"));
            }
        }
        //"server=127.0.0.1;user=root;database=iit360"
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Academic>(entity =>
            {
                entity.ToTable("academic");

                entity.Property(e => e.AcademicId)
                    .HasColumnName("academic_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcademicAdmission)
                    .IsRequired()
                    .HasColumnName("academic_admission")
                    .HasColumnType("varchar(8000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AcademicInfo)
                    .IsRequired()
                    .HasColumnName("academic_info")
                    .HasColumnType("varchar(8000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AcademicSection)
                    .IsRequired()
                    .HasColumnName("academic_section")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Programs)
                    .IsRequired()
                    .HasColumnName("programs")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<AcademicDocument>(entity =>
            {
                entity.HasKey(e => e.AcDocId)
                    .HasName("PRIMARY");

                entity.ToTable("academic_document");

                entity.HasIndex(e => e.FkAcademicAcdoc)
                    .HasName("fk_academic_acdoc");

                entity.HasIndex(e => e.FkDocumentAcdoc)
                    .HasName("fk_document_acdoc");

                entity.Property(e => e.AcDocId)
                    .HasColumnName("ac_doc_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkAcademicAcdoc)
                    .HasColumnName("fk_academic_acdoc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkDocumentAcdoc)
                    .HasColumnName("fk_document_acdoc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkAcademicAcdocNavigation)
                    .WithMany(p => p.AcademicDocument)
                    .HasForeignKey(d => d.FkAcademicAcdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academic_document_ibfk_3");

                entity.HasOne(d => d.FkDocumentAcdocNavigation)
                    .WithMany(p => p.AcademicDocument)
                    .HasForeignKey(d => d.FkDocumentAcdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("academic_document_ibfk_2");
            });

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("achievement");

                entity.HasIndex(e => e.FkAchievementImage)
                    .HasName("fk_achievement_image");

                entity.Property(e => e.AchievementId)
                    .HasColumnName("achievement_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkAchievementImage)
                    .HasColumnName("fk_achievement_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageCaption)
                    .HasColumnName("image_caption")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Venue)
                    .HasColumnName("venue")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkAchievementImageNavigation)
                    .WithMany(p => p.Achievement)
                    .HasForeignKey(d => d.FkAchievementImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("achievement_ibfk_1");
            });

            modelBuilder.Entity<Ano>(entity =>
            {
                entity.ToTable("ano");

                entity.Property(e => e.AnoId)
                    .HasColumnName("ano_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aim)
                    .IsRequired()
                    .HasColumnName("aim")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Cr>(entity =>
            {
                entity.HasKey(e => e.CrMailId)
                    .HasName("PRIMARY");

                entity.ToTable("cr");

                entity.Property(e => e.CrMailId)
                    .HasColumnName("cr_mail_id")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnName("semester")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("document_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pdf).HasColumnName("pdf");

                entity.Property(e => e.PdfName)
                    .IsRequired()
                    .HasColumnName("pdf_name")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId)
                    .HasColumnName("event_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(10000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("time");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Venue)
                    .HasColumnName("venue")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<EventImage>(entity =>
            {
                entity.HasKey(e => e.IdeventImage)
                    .HasName("PRIMARY");

                entity.ToTable("event_image");

                entity.HasIndex(e => e.FkEventEvemge)
                    .HasName("fk_event_evemge");

                entity.HasIndex(e => e.FkImageEvemge)
                    .HasName("fk_image_evemge");

                entity.Property(e => e.IdeventImage)
                    .HasColumnName("idevent-image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Caption)
                    .HasColumnName("caption")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkEventEvemge)
                    .HasColumnName("fk_event_evemge")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkImageEvemge)
                    .HasColumnName("fk_image_evemge")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkEventEvemgeNavigation)
                    .WithMany(p => p.EventImage)
                    .HasForeignKey(d => d.FkEventEvemge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_image_ibfk_1");

                entity.HasOne(d => d.FkImageEvemgeNavigation)
                    .WithMany(p => p.EventImage)
                    .HasForeignKey(d => d.FkImageEvemge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("event_image_ibfk_2");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("faculty");

                entity.HasIndex(e => e.FkFacultyImage)
                    .HasName("fk_faculty_image");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("faculty_id")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AboutMe)
                    .HasColumnName("about_me")
                    .HasColumnType("varchar(10000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkFacultyImage)
                    .HasColumnName("fk_faculty_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Links)
                    .HasColumnName("links")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Teachings)
                    .HasColumnName("teachings")
                    .HasColumnType("varchar(3000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkFacultyImageNavigation)
                    .WithMany(p => p.Faculty)
                    .HasForeignKey(d => d.FkFacultyImage)
                    .HasConstraintName("faculty_ibfk_1");
            });

            modelBuilder.Entity<FacultyPublication>(entity =>
            {
                entity.HasKey(e => e.FacPubId)
                    .HasName("PRIMARY");

                entity.ToTable("faculty_publication");

                entity.HasIndex(e => e.FkFacultyFacpub)
                    .HasName("fk_faculty_facpub");

                entity.HasIndex(e => e.FkPublicationFacpub)
                    .HasName("fk_publication_facpub");

                entity.Property(e => e.FacPubId)
                    .HasColumnName("fac_pub_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkFacultyFacpub)
                    .IsRequired()
                    .HasColumnName("fk_faculty_facpub")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkPublicationFacpub)
                    .HasColumnName("fk_publication_facpub")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkFacultyFacpubNavigation)
                    .WithMany(p => p.FacultyPublication)
                    .HasForeignKey(d => d.FkFacultyFacpub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("faculty_publication_ibfk_1");

                entity.HasOne(d => d.FkPublicationFacpubNavigation)
                    .WithMany(p => p.FacultyPublication)
                    .HasForeignKey(d => d.FkPublicationFacpub)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("faculty_publication_ibfk_2");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("history");

                entity.Property(e => e.HistoryId)
                    .HasColumnName("history_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActFrom)
                    .IsRequired()
                    .HasColumnName("act_from")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ActTo)
                    .IsRequired()
                    .HasColumnName("act_to")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DirectorName)
                    .IsRequired()
                    .HasColumnName("director_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.HeadingText)
                    .IsRequired()
                    .HasColumnName("heading_text")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RohTable)
                    .HasColumnName("roh_table")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Iitian>(entity =>
            {
                entity.HasKey(e => e.IitianMail)
                    .HasName("PRIMARY");

                entity.ToTable("iitian");

                entity.Property(e => e.IitianMail)
                    .HasColumnName("iitian_mail")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Connected)
                    .HasColumnName("connected")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.IitianName)
                    .IsRequired()
                    .HasColumnName("iitian_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("datetime");

                entity.Property(e => e.SemesterCi)
                    .HasColumnName("semester_ci")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.ImgName)
                    .IsRequired()
                    .HasColumnName("img_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("industry");

                entity.HasIndex(e => e.IndIcon)
                    .HasName("ind_icon");

                entity.Property(e => e.IndustryId)
                    .HasColumnName("industry_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Featured)
                    .HasColumnName("featured")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.IndIcon)
                    .HasColumnName("ind_icon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IndLink)
                    .HasColumnName("ind_link")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .HasColumnName("industry_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IndIconNavigation)
                    .WithMany(p => p.Industry)
                    .HasForeignKey(d => d.IndIcon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("industry_ibfk_1");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("institution");

                entity.HasIndex(e => e.FkInstImage)
                    .HasName("fk_inst_image");

                entity.Property(e => e.InstitutionId)
                    .HasColumnName("institution_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkInstImage)
                    .HasColumnName("fk_inst_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InstDescription)
                    .IsRequired()
                    .HasColumnName("inst_description")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.InstHeader)
                    .IsRequired()
                    .HasColumnName("inst_header")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkInstImageNavigation)
                    .WithMany(p => p.Institution)
                    .HasForeignKey(d => d.FkInstImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("institution_ibfk_1");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("instructor");

                entity.Property(e => e.InstructorId)
                    .HasColumnName("instructor_id")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.InstructorMail)
                    .HasColumnName("instructor_mail")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.InstructorName)
                    .HasColumnName("instructor_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("notice");

                entity.HasIndex(e => e.FkNoticeDocument)
                    .HasName("fk_notice_document");

                entity.Property(e => e.NoticeId)
                    .HasColumnName("notice_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkNoticeDocument)
                    .HasColumnName("fk_notice_document")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Section)
                    .HasColumnName("section")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("time");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkNoticeDocumentNavigation)
                    .WithMany(p => p.Notice)
                    .HasForeignKey(d => d.FkNoticeDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notice_ibfk_1");
            });

            modelBuilder.Entity<ProjectScholarship>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PRIMARY");

                entity.ToTable("project_scholarship");

                entity.HasIndex(e => e.FkFacultyProject)
                    .HasName("fk_faculty_project");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(10000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkFacultyProject)
                    .IsRequired()
                    .HasColumnName("fk_faculty_project")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProScholType)
                    .IsRequired()
                    .HasColumnName("pro_schol_type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkFacultyProjectNavigation)
                    .WithMany(p => p.ProjectScholarship)
                    .HasForeignKey(d => d.FkFacultyProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_scholarship_ibfk_1");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("publication");

                entity.Property(e => e.PublicationId)
                    .HasColumnName("publication_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PubType)
                    .HasColumnName("pub_type")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PubYear)
                    .HasColumnName("pub_year")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(1500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<PublicationDocument>(entity =>
            {
                entity.HasKey(e => e.PubDocId)
                    .HasName("PRIMARY");

                entity.ToTable("publication_document");

                entity.HasIndex(e => e.FkDocumentPubdoc)
                    .HasName("fk_document_pubdoc");

                entity.HasIndex(e => e.FkPublicationPubdoc)
                    .HasName("fk_publication_pubdoc");

                entity.Property(e => e.PubDocId)
                    .HasColumnName("pub_doc_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkDocumentPubdoc)
                    .HasColumnName("fk_document_pubdoc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPublicationPubdoc)
                    .HasColumnName("fk_publication_pubdoc")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkDocumentPubdocNavigation)
                    .WithMany(p => p.PublicationDocument)
                    .HasForeignKey(d => d.FkDocumentPubdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publication_document_ibfk_1");

                entity.HasOne(d => d.FkPublicationPubdocNavigation)
                    .WithMany(p => p.PublicationDocument)
                    .HasForeignKey(d => d.FkPublicationPubdoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("publication_document_ibfk_2");
            });

            modelBuilder.Entity<Research>(entity =>
            {
                entity.ToTable("research");

                entity.HasIndex(e => e.FkFacultyResearch)
                    .HasName("fk_faculty_research");

                entity.Property(e => e.ResearchId)
                    .HasColumnName("research_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(16000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkFacultyResearch)
                    .IsRequired()
                    .HasColumnName("fk_faculty_research")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkFacultyResearchNavigation)
                    .WithMany(p => p.Research)
                    .HasForeignKey(d => d.FkFacultyResearch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("research_ibfk_1");
            });

            modelBuilder.Entity<Researcharea>(entity =>
            {
                entity.ToTable("researcharea");

                entity.Property(e => e.ResearchAreaId)
                    .HasColumnName("research_area_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AreaDescription)
                    .IsRequired()
                    .HasColumnName("area_description")
                    .HasColumnType("varchar(5000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasColumnName("field_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.ToTable("routine");

                entity.HasIndex(e => e.FkInstructorId)
                    .HasName("fk_instructor_id");

                entity.HasIndex(e => new { e.Date, e.CourseCode, e.BeginTime, e.FkInstructorId })
                    .HasName("date")
                    .IsUnique();

                entity.Property(e => e.RoutineId)
                    .HasColumnName("routine_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BeginTime)
                    .HasColumnName("begin_time")
                    .HasColumnType("time");

                entity.Property(e => e.CourseCode)
                    .IsRequired()
                    .HasColumnName("course_code")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Dayname)
                    .HasColumnName("dayname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("time");

                entity.Property(e => e.FkInstructorId)
                    .IsRequired()
                    .HasColumnName("fk_instructor_id")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Semester)
                    .HasColumnName("semester")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkInstructor)
                    .WithMany(p => p.Routine)
                    .HasForeignKey(d => d.FkInstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("routine_ibfk_1");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffsId)
                    .HasName("PRIMARY");

                entity.ToTable("staff");

                entity.HasIndex(e => e.FkStaffImage)
                    .HasName("fk_staff_image");

                entity.Property(e => e.StaffsId)
                    .HasColumnName("staffs_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkStaffImage)
                    .HasColumnName("fk_staff_image")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkStaffImageNavigation)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.FkStaffImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staff_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
