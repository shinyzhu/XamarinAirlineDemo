﻿using AirlineDemo.PortableBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineDemo.PortableBusiness.ViewModels
{
    public class ViewModelBase : PropertyChangedBase
    {
        /// <summary>
        /// Event for when IsBusy changes
        /// </summary>
        public event EventHandler IsBusyChanged;

        /// <summary>
        /// Event for when IsValid changes
        /// </summary>
        public event EventHandler IsValidChanged;

        readonly List<string> errors = new List<string>();
        bool isBusy = false;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ViewModelBase()
        {
            //Make sure validation is performed on startup
            Validate();
        }

        /// <summary>
        /// Returns true if the current state of the ViewModel is valid
        /// </summary>
        public bool IsValid
        {
            get { return errors.Count == 0; }
        }

        /// <summary>
        /// A list of errors if IsValid is false
        /// </summary>
        protected List<string> Errors
        {
            get { return errors; }
        }

        /// <summary>
        /// An aggregated error message
        /// </summary>
        public virtual string Error
        {
            get
            {
                return errors.Aggregate(new StringBuilder(), (b, s) => b.AppendLine(s)).ToString().Trim();
            }
        }

        /// <summary>
        /// Protected method for validating the ViewModel
        /// - Fires PropertyChanged for IsValid and Errors
        /// </summary>
        protected virtual void Validate()
        {
            OnPropertyChanged("IsValid");
            OnPropertyChanged("Errors");

            var method = IsValidChanged;
            if (method != null)
                method(this, EventArgs.Empty);
        }

        /// <summary>
        /// Other viewmodels should call this when overriding Validate, to validate each property
        /// </summary>
        /// <param name="validate">Func to determine if a value is valid</param>
        /// <param name="error">The error message to use if not valid</param>
        protected virtual void ValidateProperty(Func<bool> validate, string error)
        {
            if (validate())
            {
                if (!Errors.Contains(error))
                    Errors.Add(error);
            }
            else
            {
                Errors.Remove(error);
            }
        }

        /// <summary>
        /// Value inidicating if a spinner should be shown
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;

                    OnPropertyChanged("IsBusy");
                    OnIsBusyChanged();
                }
            }
        }

        /// <summary>
        /// Other viewmodels can override this if something should be done when busy
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            var method = IsBusyChanged;
            if (method != null)
                IsBusyChanged(this, EventArgs.Empty);
        }

    }
}