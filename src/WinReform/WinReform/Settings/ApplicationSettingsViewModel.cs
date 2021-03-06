﻿using System;
using WinReform.Domain.Settings;
using WinReform.Infrastructure.Common.ViewModel;

namespace WinReform.Settings
{
    /// <summary>
    /// Defines a class that provides general application settings data
    /// </summary>
    public class ApplicationSettingsViewModel : ViewModelBase, IApplicationSettingsViewModel
    {
        ///<inheritdoc/>
        public bool UseDarkTheme
        {
            get => _useDarkTheme;
            set
            {
                SetProperty(ref _useDarkTheme, value);
                _settings.CurrentSetting.UseDarkTheme = value;
                SaveSettings();
            }
        }

        private bool _useDarkTheme = true;

        ///<inheritdoc/>
        public bool DisplayActiveWindowLocation
        {
            get => _displayActiveWindowLocation;
            set
            {
                SetProperty(ref _displayActiveWindowLocation, value);
                _settings.CurrentSetting.DisplayActiveWindowLocation = value;
                SaveSettings();
            }
        }

        private bool _displayActiveWindowLocation = false;

        ///<inheritdoc/>
        public bool MinimizeOnClose
        {
            get => _minimizeOnClose;
            set
            {
                SetProperty(ref _minimizeOnClose, value);
                _settings.CurrentSetting.MinimizeOnClose = value;
                SaveSettings();
            }
        }

        private bool _minimizeOnClose;

        ///<inheritdoc/>
        public bool AutoRefreshActiveWindows
        {
            get => _autoRefreshActiveWindows;
            set
            {
                SetProperty(ref _autoRefreshActiveWindows, value);
                _settings.CurrentSetting.AutoRefreshActiveWindows = value;
                SaveSettings();
            }
        }

        private bool _autoRefreshActiveWindows;

        /// <summary>
        /// <see cref="ISetting{TSetting}"/> containing the <see cref="ApplicationSettings"/>
        /// </summary>
        private readonly ISetting<ApplicationSettings> _settings;

        /// <summary>
        /// Create a new instance of the <see cref="ApplicationSettingsViewModel"/>
        /// <param name="applicationSettings"><see cref="ISetting{ApplicationSettings}"/> of the current app settings</param>
        /// </summary>
        public ApplicationSettingsViewModel(ISetting<ApplicationSettings> applicationSettings)
        {
            _settings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));

            // Setup view
            UseDarkTheme = _settings.CurrentSetting.UseDarkTheme;
            DisplayActiveWindowLocation = _settings.CurrentSetting.DisplayActiveWindowLocation;
            MinimizeOnClose = _settings.CurrentSetting.MinimizeOnClose;
            AutoRefreshActiveWindows = _settings.CurrentSetting.AutoRefreshActiveWindows;
        }

        /// <summary>
        /// Save the settings
        /// </summary>
        private void SaveSettings()
        {
            _settings.Save();
        }
    }
}
