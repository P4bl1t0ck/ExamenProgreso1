using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExamenProgreso1.Models;

    public class VeterinariaBasedeDatos : DbContext
    {
        public VeterinariaBasedeDatos (DbContextOptions<VeterinariaBasedeDatos> options)
            : base(options)
        {
        }

        public DbSet<ExamenProgreso1.Models.Cita> Cita { get; set; } = default!;

public DbSet<ExamenProgreso1.Models.Dueno> Dueno { get; set; } = default!;

public DbSet<ExamenProgreso1.Models.Mascota> Mascota { get; set; } = default!;
    }
