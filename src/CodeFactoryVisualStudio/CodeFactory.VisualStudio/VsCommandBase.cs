﻿//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;
using CodeFactory.Logging;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Base implementation for a factory command that supports integration with visual studio.
    /// </summary>
    /// <typeparam name="TModel">The target visual studio model type to be returned from the visual studio command.</typeparam>
    public abstract class VsCommandBase<TModel> : IVsFactoryCommand<TModel> where TModel : class
    {
        /// <summary>
        /// Backing field for the property <see cref="CommandTitle"/>
        /// </summary>
        protected readonly string _commandTitle;

        /// <summary>
        /// Backing field for the property <see cref="CommandDescription"/>
        /// </summary>
        protected readonly  string _commandDescription;

        /// <summary>
        /// Backing field for the property <see cref="CommandType"/>
        /// </summary>
        private readonly VsCommandType _commandType;

        /// <summary>
        /// Logging method that is used by the command to log to the code factory logging framework.
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Backing field for the property <see cref="VisualStudioActions"/>
        /// </summary>
        private readonly  IVsActions _visualStudioActions;

        /// <summary>
        /// Base constructor used it initialize a visual studio command.
        /// </summary>
        /// <param name="logger">The code factory logger to be used by the logger.</param>
        /// <param name="commands">The global visual studio commands that can be used by this visual studio command.</param>
        /// <param name="commandType">The target type of command being created. </param>
        /// <param name="commandTitle">The title displayed in visual studio for this command.</param>
        /// <param name="commandDescription">A brief description of the purpose of this command.</param>
        protected VsCommandBase(ILogger logger, IVsActions commands, VsCommandType commandType,string commandTitle, string commandDescription)
        {
            _logger = logger;
            _commandType = commandType;
            _visualStudioActions = commands;
            _commandTitle = commandTitle;
            _commandDescription = commandDescription;
        }

        #region Implementation of IVsCommandInformation

        /// <summary>
        /// Action title that will be displayed within visual studio.
        /// </summary>
        public string CommandTitle => _commandTitle;

        /// <summary>
        /// An optional discription that discribes what this factory command is intended for. 
        /// </summary>
        public string CommandDescription => _commandDescription;

        /// <summary>
        /// The target type of command that is being loaded.
        /// </summary>
        public VsCommandType CommandType => _commandType;

        #endregion

        #region Implementation of ICommand<TModel>

        /// <summary>
        /// Validation logic that will determine if this command should be enabled for execution.
        /// </summary>
        /// <param name="result">The target model data that will be used to determine if this command should be enabled.</param>
        /// <returns>Boolean flag that will tell code factory to enable this command or disable it.</returns>
        public abstract Task<bool> EnableCommandAsync(TModel result);


        /// <summary>
        /// Code factory framework calls this method when the command has been executed. 
        /// </summary>
        /// <param name="result">The code factory model that has generated and provided to the command to process.</param>
        public abstract Task ExecuteCommandAsync(TModel result);


        #endregion

        #region Implementation of IVsFactoryCommand<TModel>

        /// <summary>
        /// Global visual studio commands that can be accessed from this visual studio command.
        /// </summary>
        public IVsActions VisualStudioActions => _visualStudioActions;

        #endregion
    }
}
