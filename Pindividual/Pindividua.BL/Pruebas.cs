using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pindividual.DAL;

namespace Pindividual.BL
{
    namespace PIndividual.BL
    {
        public class Prueba
        {

            public void Insertar()
            {
                Vuelos v1 = new Vuelos();
                v1.Id_vuelo = 5;
                v1.Escala = "xxx";
                v1.Duracion = 5;


                Aviones A1 = new Aviones();
                A1.Id = 4;
                A1.Modelo = "Airbus456";
                A1.Asientos = "568";
                A1.Cantidad = 684;


                Paises_Destino_Aeropuerto PDA = new Paises_Destino_Aeropuerto();
                PDA.id = 6;
                PDA.id_vuelo = 5;
                PDA.Paises = "USA";
                PDA.Destino = "New York";
                PDA.Aeropuerto = "Juan Santa Maria ";
                PDA.Tarifa = 564;

                Pasajeros pj = new Pasajeros();
                pj.id = 8;
                pj.Id_vuelo = 5;
                pj.Nombre = "Nombre 1";
                pj.Apellidos = "Apellidos 1";
                pj.Visa = 454221;
                pj.Pasaporte = 26564;





                using (AeropuertoEntities context = new AeropuertoEntities())
                {

                    context.Vuelos.Add(v1);
                    context.SaveChanges();

                }

            }



            public void PruebaSelect()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    var vuelos = context.Vuelos.ToList();
                    var aviones = context.Aviones.ToList();
                    var pasajeros = context.Pasajeros.ToList();
                    var PaisesDestinoAeropuerto = context.Paises_Destino_Aeropuerto.ToList();
                    



                }


            }

            public void PruebaWhereVuelos()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Id_vuelo == 4);

                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");
                    }

                }
            }

            public void PruebaWhereVuelos2()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Duracion == 5);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("e");
                    }
                }


            }



            public void PruebaJoin()
            {


                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    //T representa una tupla en este caso tenemos T1 que es la tupla 1 y t2 que es la tupla 2 
                    //T Este caso presenta un Inner Join
                    try
                    {
                        var vuelos = context.Vuelos.Join(context.Paises_Destino_Aeropuerto,
                            t2 => t2.Id_vuelo,
                            t1 => t1.id,
                            (t1, t2) => new
                            {

                                escala = t1.Escala,
                                destino = t2.Destino

                            }
                            ).ToList();
                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");

                    }

                }



            }



            public void PruebaWhereSelect()
            {
                //T lambda es una funcion en este ejemplo s es esa funcion sx tiene la misma función

                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelos = context.Vuelos.Where(x => x.Duracion == 5).Select(s =>
                        new
                        {

                            Escala = s.Escala,
                            Duracion = s.Duracion


                        }
                        ).ToList();

                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("e");
                    }

                }



            }

            public void PruebaUpdate()
            {
                //

                using (AeropuertoEntities context = new AeropuertoEntities())
                {
                    try
                    {
                        var vuelo = context.Vuelos.Where(x => x.Duracion == 5).SingleOrDefault();
                        vuelo.Escala = "CAMBIO";
                        context.SaveChanges();

                        var Aviones = context.Aviones.Where(x => x.Cantidad == 1).SingleOrDefault();
                        Aviones.Asientos = "CAMBIO";
                        context.SaveChanges();

                        var Pasajeros = context.Pasajeros.Where(x => x.Id_vuelo == 4).SingleOrDefault();
                        Pasajeros.Nombre = "CAMBIO";
                        context.SaveChanges();

                        var PaisesDestinoAeropuerto = context.Paises_Destino_Aeropuerto.Where(x => x.Tarifa == 1).SingleOrDefault();
                        PaisesDestinoAeropuerto.Destino = "CAMBIO";
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {


                        Console.WriteLine(" prueba Update vuelo e");
                    }

                }


            }
        }
    }
}