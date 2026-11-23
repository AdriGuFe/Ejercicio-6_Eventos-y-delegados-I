using System;

namespace Ejercicio1
{
    class VentaEventArgs : EventArgs
    {
        public string Producto { get; }
        public double Precio { get; }

        public VentaEventArgs(string producto, double precio)
        {
            Producto = producto;
            Precio = precio;
        }
    }

    class RegistroVentas
    {
        public event EventHandler<VentaEventArgs> VentaRealizada;

        public void ProcesarVenta(string producto, double precio)
        {
            Console.WriteLine($"Procesando venta de {producto}...");
            VentaRealizada?.Invoke(this, new VentaEventArgs(producto, precio));
        }
    }

    class ServicioRegistro
    {
        public void RegistrarVenta(object sender, VentaEventArgs e)
        {
            Console.WriteLine($"Venta registrada: {e.Producto} por {e.Precio} €");
        }
    }

    class ServicioNotificacion
    {
        public void EnviarNotificacionVenta(object sender, VentaEventArgs e)
        {
            Console.WriteLine($"Notificación enviada al usuario: se ha vendido {e.Producto} por {e.Precio} €");
        }
    }
}

namespace Ejercicio2
{
    class TemperaturaEventArgs : EventArgs
    {
        public double TemperaturaActual { get; }
        public double Umbral { get; }

        public TemperaturaEventArgs(double temperaturaActual, double umbral)
        {
            TemperaturaActual = temperaturaActual;
            Umbral = umbral;
        }
    }

    class ControlTemperatura
    {
        private double umbral;

        public event EventHandler<TemperaturaEventArgs> TemperaturaAlta;

        public ControlTemperatura(double umbral)
        {
            this.umbral = umbral;
        }

        public void MedirTemperatura(double temperatura)
        {
            Console.WriteLine($"Temperatura medida: {temperatura} °C");
            if (temperatura > umbral)
            {
                TemperaturaAlta?.Invoke(this, new TemperaturaEventArgs(temperatura, umbral));
            }
        }
    }

    class ServicioAlerta
    {
        public void EnviarAlerta(object sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"ALERTA: la temperatura {e.TemperaturaActual} °C supera el umbral de {e.Umbral} °C");
        }
    }

    class ServicioRegistroTemperatura
    {
        public void RegistrarTemperatura(object sender, TemperaturaEventArgs e)
        {
            Console.WriteLine($"Temperatura registrada: {e.TemperaturaActual} °C");
        }
    }
}

namespace Ejercicio3
{
    class BackupEventArgs : EventArgs
    {
        public string NombreArchivo { get; }
        public DateTime Fecha { get; }

        public BackupEventArgs(string nombreArchivo, DateTime fecha)
        {
            NombreArchivo = nombreArchivo;
            Fecha = fecha;
        }
    }

    class GestorBackups
    {
        public event EventHandler<BackupEventArgs> BackupCompletado;

        public void RealizarBackup(string nombreArchivo)
        {
            Console.WriteLine($"Realizando copia de seguridad de {nombreArchivo}...");
            BackupCompletado?.Invoke(this, new BackupEventArgs(nombreArchivo, DateTime.Now));
        }
    }

    class ServicioNotificacion
    {
        public void EnviarNotificacion(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"Notificación: la copia de {e.NombreArchivo} se ha completado");
        }
    }

    class ServicioLog
    {
        public void RegistrarOperacion(object sender, BackupEventArgs e)
        {
            Console.WriteLine($"Log: copia de {e.NombreArchivo} realizada el {e.Fecha}");
        }
    }
}

namespace Ejercicio4
{
    class IntrusoEventArgs : EventArgs
    {
        public string NombreSensor { get; }
        public DateTime HoraDeteccion { get; }

        public IntrusoEventArgs(string nombreSensor, DateTime horaDeteccion)
        {
            NombreSensor = nombreSensor;
            HoraDeteccion = horaDeteccion;
        }
    }

    class SensorMonitoreo
    {
        private TimeSpan inicioPermitido;
        private TimeSpan finPermitido;

        public event EventHandler<IntrusoEventArgs> AlertaIntruso;

        public SensorMonitoreo(TimeSpan inicioPermitido, TimeSpan finPermitido)
        {
            this.inicioPermitido = inicioPermitido;
            this.finPermitido = finPermitido;
        }

        public void DetectarApertura(string nombreSensor, DateTime hora)
        {
            Console.WriteLine($"{nombreSensor} abierta a las {hora:HH:mm}");
            if (hora.TimeOfDay < inicioPermitido || hora.TimeOfDay > finPermitido)
            {
                AlertaIntruso?.Invoke(this, new IntrusoEventArgs(nombreSensor, hora));
            }
        }
    }

    class ServicioAlarma
    {
        public void ActivarAlarma(object sender, IntrusoEventArgs e)
        {
            Console.WriteLine($"ALARMA ACTIVADA: {e.NombreSensor} abierta fuera de horario a las {e.HoraDeteccion:HH:mm}");
        }
    }

    class ServicioRegistroIncidencias
    {
        public void GuardarIncidencia(object sender, IntrusoEventArgs e)
        {
            Console.WriteLine($"Incidencia guardada en la base de datos: {e.NombreSensor} a las {e.HoraDeteccion:HH:mm}");
        }
    }
}

namespace Ejercicio5
{
    class EnergiaEventArgs : EventArgs
    {
        public double ConsumoActual { get; }
        public double Umbral { get; }

        public EnergiaEventArgs(double consumoActual, double umbral)
        {
            ConsumoActual = consumoActual;
            Umbral = umbral;
        }
    }

    class MonitorEnergia
    {
        private double umbral;

        public event EventHandler<EnergiaEventArgs> ConsumoExcesivoDetectado;

        public MonitorEnergia(double umbral)
        {
            this.umbral = umbral;
        }

        public void RegistrarConsumo(double consumo)
        {
            Console.WriteLine($"Consumo registrado: {consumo} kWh");
            if (consumo > umbral)
            {
                ConsumoExcesivoDetectado?.Invoke(this, new EnergiaEventArgs(consumo, umbral));
            }
        }
    }

    class ServicioNotificacion
    {
        public void EnviarAdvertencia(object sender, EnergiaEventArgs e)
        {
            Console.WriteLine($"Advertencia al usuario: consumo de {e.ConsumoActual} kWh por encima del umbral de {e.Umbral} kWh");
        }
    }

    class ServicioAjusteAutomatizado
    {
        public void AjustarDispositivos(object sender, EnergiaEventArgs e)
        {
            Console.WriteLine("Ajustando dispositivos automáticamente para reducir el consumo");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 1");
        Ejercicio1.RegistroVentas registroVentas = new Ejercicio1.RegistroVentas();
        Ejercicio1.ServicioRegistro servicioRegistro = new Ejercicio1.ServicioRegistro();
        Ejercicio1.ServicioNotificacion servicioNotificacionVentas = new Ejercicio1.ServicioNotificacion();
        registroVentas.VentaRealizada += servicioRegistro.RegistrarVenta;
        registroVentas.VentaRealizada += servicioNotificacionVentas.EnviarNotificacionVenta;
        registroVentas.ProcesarVenta("Portátil", 899.99);
        Console.WriteLine();

        Console.WriteLine("Ejercicio 2");
        Ejercicio2.ControlTemperatura controlTemperatura = new Ejercicio2.ControlTemperatura(30);
        Ejercicio2.ServicioAlerta servicioAlerta = new Ejercicio2.ServicioAlerta();
        Ejercicio2.ServicioRegistroTemperatura servicioRegistroTemperatura = new Ejercicio2.ServicioRegistroTemperatura();
        controlTemperatura.TemperaturaAlta += servicioAlerta.EnviarAlerta;
        controlTemperatura.TemperaturaAlta += servicioRegistroTemperatura.RegistrarTemperatura;
        controlTemperatura.MedirTemperatura(25);
        controlTemperatura.MedirTemperatura(36.5);
        Console.WriteLine();

        Console.WriteLine("Ejercicio 3");
        Ejercicio3.GestorBackups gestorBackups = new Ejercicio3.GestorBackups();
        Ejercicio3.ServicioNotificacion servicioNotificacionBackups = new Ejercicio3.ServicioNotificacion();
        Ejercicio3.ServicioLog servicioLog = new Ejercicio3.ServicioLog();
        gestorBackups.BackupCompletado += servicioNotificacionBackups.EnviarNotificacion;
        gestorBackups.BackupCompletado += servicioLog.RegistrarOperacion;
        gestorBackups.RealizarBackup("documentos.zip");
        Console.WriteLine();

        Console.WriteLine("Ejercicio 4");
        Ejercicio4.SensorMonitoreo sensorMonitoreo = new Ejercicio4.SensorMonitoreo(new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0));
        Ejercicio4.ServicioAlarma servicioAlarma = new Ejercicio4.ServicioAlarma();
        Ejercicio4.ServicioRegistroIncidencias servicioRegistroIncidencias = new Ejercicio4.ServicioRegistroIncidencias();
        sensorMonitoreo.AlertaIntruso += servicioAlarma.ActivarAlarma;
        sensorMonitoreo.AlertaIntruso += servicioRegistroIncidencias.GuardarIncidencia;
        sensorMonitoreo.DetectarApertura("Puerta principal", new DateTime(2026, 11, 23, 14, 30, 0));
        sensorMonitoreo.DetectarApertura("Ventana del salón", new DateTime(2026, 11, 23, 3, 15, 0));
        Console.WriteLine();

        Console.WriteLine("Ejercicio 5");
        Ejercicio5.MonitorEnergia monitorEnergia = new Ejercicio5.MonitorEnergia(500);
        Ejercicio5.ServicioNotificacion servicioNotificacionEnergia = new Ejercicio5.ServicioNotificacion();
        Ejercicio5.ServicioAjusteAutomatizado servicioAjusteAutomatizado = new Ejercicio5.ServicioAjusteAutomatizado();
        monitorEnergia.ConsumoExcesivoDetectado += servicioNotificacionEnergia.EnviarAdvertencia;
        monitorEnergia.ConsumoExcesivoDetectado += servicioAjusteAutomatizado.AjustarDispositivos;
        monitorEnergia.RegistrarConsumo(320);
        monitorEnergia.RegistrarConsumo(640);
    }
}
