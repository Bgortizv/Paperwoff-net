using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PaperwoffNet.Infrastructure;

namespace PaperwoffNet.Infrastructure.Data
{
    public partial class PaperwoffNetDbContext : DbContext
    {
        public PaperwoffNetDbContext()
        {
        }

        public PaperwoffNetDbContext(DbContextOptions<PaperwoffNetDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Asignaturaxtutor> Asignaturaxtutor { get; set; }
        public virtual DbSet<BolsaPagos> BolsaPagos { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Disponibilidad> Disponibilidad { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TipoClase> TipoClase { get; set; }
        public virtual DbSet<Tutores> Tutores { get; set; }
        public virtual DbSet<Tutorias> Tutorias { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Virpres> Virpres { get; set; }
        public virtual DbSet<VwInfotutorias> VwInfotutorias { get; set; }
        public virtual DbSet<VwSeleccionarTutorDisponible> VwSeleccionarTutorDisponible { get; set; }
        public virtual DbSet<VwTutores> VwTutores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
  //              optionsBuilder.UseMySQL("database=tyt;server=localhost;port=3306;user id=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.IdAsignatura)
                    .HasName("PRIMARY");

                entity.ToTable("asignatura");

                entity.Property(e => e.IdAsignatura)
                    .HasColumnName("id_Asignatura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Código)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreAsignatura)
                    .HasColumnName("Nombre_Asignatura")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Asignaturaxtutor>(entity =>
            {
                entity.HasKey(e => e.IdAxT)
                    .HasName("PRIMARY");

                entity.ToTable("asignaturaxtutor");

                entity.HasIndex(e => e.AsignaturaIdAsignatura)
                    .HasName("asignaturaxtutor_ibfk_2");

                entity.HasIndex(e => e.TutoresIdTutores)
                    .HasName("asignaturaxtutor_ibfk_1");

                entity.Property(e => e.IdAxT)
                    .HasColumnName("id_AxT")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AsignaturaIdAsignatura)
                    .HasColumnName("Asignatura_id_Asignatura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Estado).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TutoresIdTutores)
                    .HasColumnName("Tutores_id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.AsignaturaIdAsignaturaNavigation)
                    .WithMany(p => p.Asignaturaxtutor)
                    .HasForeignKey(d => d.AsignaturaIdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asignaturaxtutor_ibfk_2");

                entity.HasOne(d => d.TutoresIdTutoresNavigation)
                    .WithMany(p => p.Asignaturaxtutor)
                    .HasForeignKey(d => d.TutoresIdTutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asignaturaxtutor_ibfk_1");
            });

            modelBuilder.Entity<BolsaPagos>(entity =>
            {
                entity.HasKey(e => e.IdBolsaPagos)
                    .HasName("PRIMARY");

                entity.ToTable("bolsa_pagos");

                entity.HasIndex(e => e.EstudiantesIdEstudiantes)
                    .HasName("bolsa_pagos_ibfk_1");

                entity.Property(e => e.IdBolsaPagos)
                    .HasColumnName("id_Bolsa_Pagos")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EstudiantesIdEstudiantes)
                    .HasColumnName("Estudiantes_id_Estudiantes")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TotalAbonos)
                    .HasColumnName("Total_Abonos")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalDescuentos)
                    .HasColumnName("Total_Descuentos")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.EstudiantesIdEstudiantesNavigation)
                    .WithMany(p => p.BolsaPagos)
                    .HasForeignKey(d => d.EstudiantesIdEstudiantes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bolsa_pagos_ibfk_1");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_factura");

                entity.HasIndex(e => e.AsignaturaIdAsignatura)
                    .HasName("detalle_factura_ibfk_1");

                entity.HasIndex(e => e.FacturaIdFactura)
                    .HasName("detalle_factura_ibfk_2");

                entity.Property(e => e.IdDetalleFactura)
                    .HasColumnName("id_Detalle_Factura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AsignaturaIdAsignatura)
                    .HasColumnName("Asignatura_id_Asignatura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CantidadHoras)
                    .HasColumnName("Cantidad_Horas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FacturaIdFactura)
                    .HasColumnName("Factura_id_Factura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("Valor_Total")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.AsignaturaIdAsignaturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.AsignaturaIdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalle_factura_ibfk_1");

                entity.HasOne(d => d.FacturaIdFacturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.FacturaIdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detalle_factura_ibfk_2");
            });

            modelBuilder.Entity<Disponibilidad>(entity =>
            {
                entity.HasKey(e => e.IdDisponibilidad)
                    .HasName("PRIMARY");

                entity.ToTable("disponibilidad");

                entity.HasIndex(e => e.TutoresIdTutores)
                    .HasName("disponibilidad_ibfk_1");

                entity.Property(e => e.IdDisponibilidad)
                    .HasColumnName("id_Disponibilidad")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HoraFin)
                    .HasColumnName("Hora_fin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("Hora_inicio")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TutoresIdTutores)
                    .HasColumnName("Tutores_id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.TutoresIdTutoresNavigation)
                    .WithMany(p => p.Disponibilidad)
                    .HasForeignKey(d => d.TutoresIdTutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disponibilidad_ibfk_1");
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEstudiantes)
                    .HasName("PRIMARY");

                entity.ToTable("estudiantes");

                entity.HasIndex(e => e.UsersIdUser)
                    .HasName("estudiantes_ibfk_1");

                entity.Property(e => e.IdEstudiantes)
                    .HasColumnName("id_Estudiantes")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Acudiente)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CelularAcudiente)
                    .HasColumnName("Celular_Acudiente")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Grado)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UsersIdUser)
                    .HasColumnName("Users_id_user")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.UsersIdUserNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.UsersIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estudiantes_ibfk_1");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasIndex(e => e.TutoresIdTutores)
                    .HasName("factura_ibfk_1");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("id_Factura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("Fecha_Creacion")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FinPeriodo)
                    .HasColumnName("Fin_Periodo")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IncioPeriodo)
                    .HasColumnName("Incio_Periodo")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TotalHoras)
                    .HasColumnName("Total_horas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TutoresIdTutores)
                    .HasColumnName("Tutores_id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.TutoresIdTutoresNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.TutoresIdTutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("factura_ibfk_1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.IdRole)
                    .HasColumnName("id_Role")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreRol)
                    .HasColumnName("nombre_Rol")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TipoClase>(entity =>
            {
                entity.HasKey(e => e.IdTipoClase)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_clase");

                entity.Property(e => e.IdTipoClase)
                    .HasColumnName("id_Tipo_Clase")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Tutores>(entity =>
            {
                entity.HasKey(e => e.IdTutores)
                    .HasName("PRIMARY");

                entity.ToTable("tutores");

                entity.HasIndex(e => e.UsersIdUser)
                    .HasName("tutores_ibfk_1");

                entity.Property(e => e.IdTutores)
                    .HasColumnName("id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Profesion)
                    .HasColumnName("profesion")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UsersIdUser)
                    .HasColumnName("Users_id_User")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.UsersIdUserNavigation)
                    .WithMany(p => p.Tutores)
                    .HasForeignKey(d => d.UsersIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutores_ibfk_1");
            });

            modelBuilder.Entity<Tutorias>(entity =>
            {
                entity.HasKey(e => e.IdTutorias)
                    .HasName("PRIMARY");

                entity.ToTable("tutorias");

                entity.HasIndex(e => e.AsignaturaIdAsignatura)
                    .HasName("tutorias_ibfk_3");

                entity.HasIndex(e => e.EstudiantesIdEstudiantes)
                    .HasName("tutorias_ibfk_4");

                entity.HasIndex(e => e.TipoClaseIdTipoClase)
                    .HasName("tutorias_ibfk_5");

                entity.HasIndex(e => e.TutoresIdTutores)
                    .HasName("tutorias_ibfk_2");

                entity.HasIndex(e => e.UsersIdUser)
                    .HasName("tutorias_ibfk_1");

                entity.HasIndex(e => e.VirPresIdVirPres)
                    .HasName("tutorias_ibfk_6");

                entity.Property(e => e.IdTutorias)
                    .HasColumnName("id_Tutorias")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AsignaturaIdAsignatura)
                    .HasColumnName("Asignatura_id_Asignatura")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CantidadHoras)
                    .HasColumnName("Cantidad_Horas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EstudiantesIdEstudiantes)
                    .HasColumnName("Estudiantes_id_Estudiantes")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.HoraFin).HasColumnName("Hora_fin");

                entity.Property(e => e.HoraInicio).HasColumnName("Hora_inicio");

                entity.Property(e => e.Paga).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TipoClaseIdTipoClase)
                    .HasColumnName("Tipo_Clase_id_Tipo_Clase")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Total)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Transporte)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TutoresIdTutores)
                    .HasColumnName("Tutores_id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.UsersIdUser)
                    .HasColumnName("Users_id_User")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.VirPresIdVirPres)
                    .HasColumnName("VirPres_id_VirPres")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.AsignaturaIdAsignaturaNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.AsignaturaIdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_3");

                entity.HasOne(d => d.EstudiantesIdEstudiantesNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.EstudiantesIdEstudiantes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_4");

                entity.HasOne(d => d.TipoClaseIdTipoClaseNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.TipoClaseIdTipoClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_5");

                entity.HasOne(d => d.TutoresIdTutoresNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.TutoresIdTutores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_2");

                entity.HasOne(d => d.UsersIdUserNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.UsersIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_1");

                entity.HasOne(d => d.VirPresIdVirPresNavigation)
                    .WithMany(p => p.Tutorias)
                    .HasForeignKey(d => d.VirPresIdVirPres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tutorias_ibfk_6");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.RoleIdRole)
                    .HasName("users_ibfk_1");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_User")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Celular)
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Documento)
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EMail)
                    .HasColumnName("e_mail")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Estado).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(512)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RoleIdRole)
                    .HasColumnName("Role_id_role")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RoleIdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleIdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_1");
            });

            modelBuilder.Entity<Virpres>(entity =>
            {
                entity.HasKey(e => e.IdVirPres)
                    .HasName("PRIMARY");

                entity.ToTable("virpres");

                entity.Property(e => e.IdVirPres)
                    .HasColumnName("id_VirPres")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<VwInfotutorias>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_infotutorias");

                entity.Property(e => e.NombreAsignatura)
                    .HasColumnName("Nombre_Asignatura")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreEstudiante)
                    .HasMaxLength(41)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreTutor)
                    .HasMaxLength(41)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<VwSeleccionarTutorDisponible>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_seleccionar_tutor_disponible");

                entity.Property(e => e.IdTutores)
                    .HasColumnName("id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.NombreTutor)
                    .HasMaxLength(41)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<VwTutores>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_tutores");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdTutores)
                    .HasColumnName("id_Tutores")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Profesion)
                    .HasColumnName("profesion")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UsersIdUser)
                    .HasColumnName("Users_id_User")
                    .HasColumnType("bigint(20)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
