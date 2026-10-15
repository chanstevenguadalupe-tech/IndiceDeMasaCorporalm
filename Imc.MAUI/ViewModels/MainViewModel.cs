using Imc.MAUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Imc.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _peso;
        private string _estatura;
        private string _imc;
        private string _estadoNutricional;
        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }
        public MainViewModel()
        {
            Limpiar();
            CalcularCommand = new Command(Calcular);
            LimpiarCommand = new Command(Limpiar);

        }
        public string Peso
        {
            get => _peso;
            set
            {
                if (value != _peso)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso));
                }
            }
        }
        public string Estatura
        {
            get => _estatura;
            set
            {
                if (_estatura != value)
                {
                    _estatura = value;
                    OnPropertyChanged(nameof(Estatura));
                }
            }
        }
        public string Imc
        {
            get => _imc;
            set
            {
                if (value != _imc)
                {
                    _imc = value;
                    OnPropertyChanged(nameof(Imc));
                }
            }
        }
        public string EstadoNutricional
        {
            get => _estadoNutricional;
            set
            {
                if (value != _estadoNutricional)
                {
                    _estadoNutricional = value;
                    OnPropertyChanged(nameof(EstadoNutricional));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Calcular()
        {
            decimal peso;
            decimal estatura;
            bool pesoEsValido = decimal.TryParse(Peso, out peso);
            bool estaturaEsValido = decimal.TryParse(Estatura, out estatura);
            if (pesoEsValido && estaturaEsValido)
            {
                decimal imc = CalculadoraImc.IndiceDeMasaCorporal(peso, estatura);
                Imc = imc.ToString("F4");
                EstadoNutricional = CalculadoraImc.EstadoNutricional(imc);
            }

        }

        private void Limpiar()
        {
            Peso = string.Empty;
            Estatura = string.Empty;
            Imc = string.Empty;
            EstadoNutricional = string.Empty;
        }
    }

}