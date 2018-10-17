﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Chinook.DataAccess.Repository;
using Chinook.DataAccess.Repository.Interfaces;
using Chinook.Entities.Base;

namespace Chinook.Services.wcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MantenimientosServices : IMantenimientosServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly DbContext dbContext;

        public MantenimientosServices()
        {
            dbContext = new ChinookDBModel();
            unitOfWork = new UnitOfWork(dbContext);
        }


        public IEnumerable<Artist> GetArtistByName(string artistName)
        {
            var artists = unitOfWork.ArtistRepository.GetListByName(artistName);
            return artists;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
