﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace JR.CodeGenerator.ViewModels;

/// <summary>
/// MainViewModel
/// </summary>
/// <autogeneratedoc />
public class MainViewModel : ObservableObject
{
    private bool isIntegrateSecurity;
    private bool isEnableUderPass;
    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <autogeneratedoc />
    public MainViewModel()
    {

    }


    /// <summary>
    /// Gets or sets a value indicating whether this instance is integrate security.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is integrate security; otherwise, <c>false</c>.
    /// </value>
    /// <autogeneratedoc />
    public bool IsIntegrateSecurity
    {
        get => isIntegrateSecurity;
        set
        {
            SetProperty(ref isIntegrateSecurity, value);
            IsEnableUderPass = !value;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is enable uder pass.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is enable uder pass; otherwise, <c>false</c>.
    /// </value>
    /// <autogeneratedoc />
    public bool IsEnableUderPass
    {
        get => isEnableUderPass;
        set => SetProperty(ref isEnableUderPass, value);
    }




}
