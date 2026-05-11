using System;
using Proyecto_banco;

public class Banco
{
    private ListaEnlazada<Cliente> clientes;
    private Cola<Cliente> colaAtencion;
    private Pila<Transaccion> historialTransacciones;

    //Constructor
    public Banco()
    {
        clientes = new ListaEnlazada<Cliente>();
        colaAtencion = new Cola<Cliente>();
        historialTransacciones = new Pila<Transaccion>();
    }

    // Crear/Agregar elementos
    public void RegistrarCliente(Cliente cliente)
    {
        clientes.Insertar(cliente);
    }

    public void AgregarACola(Cliente cliente)
    {
        colaAtencion.Encolar(cliente);
    }

    public void RealizarTransaccion(Transaccion transaccion)
    {
        historialTransacciones.Push(transaccion);
    }

    // Eliminar elementos
    public void EliminarCliente(Func<Cliente, bool> criterio)
    {
        clientes.Eliminar(criterio);
    }

    public Cliente DesencolarCliente()
    {
        return colaAtencion.Desencolar();
    }

    public Transaccion DesapilarTransaccion()
    {
        return historialTransacciones.Pop();
    }

    // Recorrer/Enlistar elementos
    public void RecorrerClientes(Action<Cliente> accion)
    {
        clientes.Recorrer(accion);
    }

    public void RecorrerColaAtencion(Action<Cliente> accion)
    {
        colaAtencion.Recorrer(accion);
    }

    public void RecorrerHistorialTransacciones(Action<Transaccion> accion)
    {
        historialTransacciones.Recorrer(accion);
    }
}
