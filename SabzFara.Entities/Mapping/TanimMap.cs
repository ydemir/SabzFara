﻿using SabzFara.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.Mapping
{
   public class TanimMap :EntityTypeConfiguration<Tanim>
    {
        public TanimMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(p => p.Turu).HasMaxLength(15);
            this.Property(p => p.Tanimi).HasMaxLength(30);
            this.Property(p => p.Aciklama).HasMaxLength(200);


            this.ToTable("Tanimlar");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Turu).HasColumnName("Turu");
            this.Property(p => p.Tanimi).HasColumnName("Tanimi");
            this.Property(p => p.Aciklama).HasColumnName("Aciklama");
        }
    }
}
