using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjemploMVC.Models
{
    public class VistaGenero
    {
        public List<Videos> L_Videos;
        public SelectList Generos;
        public string generoVideo { get; set; }


    }
}
