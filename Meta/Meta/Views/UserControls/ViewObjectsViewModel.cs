using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;
using Flattsware;
using Flattsware.Helpers;
using NHibernate.Util;

namespace Meta.Views.UserControls
{
    public class ViewObjectsViewModel<T> : ViewObjectsViewModel where T : NHibernateObject
    {
        private bool _filterVisible;
        private ObservableCollection<T> _objects;
        private ObservableCollection<T> _filteredObjects;
        private ObservableCollection<EditableProperty> _properties;
        private ICommand _toggleVisibleCommand;
        private ICommand _deleteFilterCommand;
        private ICommand _applyFilterCommand;

        public ViewObjectsViewModel(ObservableCollection<T> objects)
        {
            Objects = objects;
        }

        public ViewObjectsViewModel(IEnumerable<T> objects)
        {
            Objects = new ObservableCollection<T>(objects);
            FilteredObjects = Objects;
        }

        public ObservableCollection<T> Objects
        {
            get { return _objects; }
            set { SetProperty(ref _objects, value); }
        }

        public ObservableCollection<T> FilteredObjects
        {
            get { return _filteredObjects; }
            set { SetProperty(ref _filteredObjects, value); }
        }

        public bool FilterVisible
        {
            get { return _filterVisible; }
            set { SetProperty(ref _filterVisible, value); }
        }

        public string PluralOfObjectTypeName
            =>
                PluralizationService.CreateService(CultureInfo.CurrentCulture)
                    .Pluralize(Objects.GetCollectionElementType().Name);

        public ICommand ToggleVisibleCommand
            =>
                _toggleVisibleCommand ??
                (_toggleVisibleCommand = new DelegateCommand(() => FilterVisible = !FilterVisible));

        public ICommand DeleteFilterCommand
            => _deleteFilterCommand ?? (_deleteFilterCommand = new DelegateCommand(DeleteFilter));

        public ICommand ApplyFilterCommand
            => _applyFilterCommand ?? (_applyFilterCommand = new DelegateCommand(ApplyFilter));

        private void ApplyFilter()
        {
            foreach (var property in Properties)
            {
                // Skip the property if the user inputs nothing.
                if (property.IsNull() || property.Input.IsNull() || property.Input.ToString().IsNullOrEmpty()) continue;

                FilteredObjects = property.Operator.Filter(Objects, property);
            }
        }

        private void DeleteFilter()
        {
            FilteredObjects = Objects;
        }

        public ObservableCollection<EditableProperty> Properties => _properties ?? (_properties = new ObservableCollection<EditableProperty>(Objects.GetCollectionElementType().GetFilteredProperties().ToListOfEditableProperties()));
    }

    public abstract class ViewObjectsViewModel : BindableBase, IUserControlViewModel
    {
    }
}