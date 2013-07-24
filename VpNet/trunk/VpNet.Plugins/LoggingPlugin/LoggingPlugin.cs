﻿#region Copyright notice
/*
____   ___.__         __               .__    __________                        .__.__                
\   \ /   |__________/  |_ __ _______  |  |   \______   _____ ____________    __| _|__| ______ ____   
 \   Y   /|  \_  __ \   __|  |  \__  \ |  |    |     ___\__  \\_  __ \__  \  / __ ||  |/  ____/ __ \  
  \     / |  ||  | \/|  | |  |  // __ \|  |__  |    |    / __ \|  | \// __ \/ /_/ ||  |\___ \\  ___/  
   \___/  |__||__|   |__| |____/(____  |____/  |____|   (____  |__|  (____  \____ ||__/____  >\___  > 
                                     \/                      \/           \/     \/        \/     \/  
    This file is part of VPNET Version 1.0

    Copyright (c) 2012-2013 CUBE3 (Cit:36)

    VPNET is free software: you can redistribute it and/or modify it under the terms of the 
    GNU Lesser General Public License (LGPL) as published by the Free Software Foundation, either
    version 2.1 of the License, or (at your option) any later version.

    VPNET is distributed in the hope that it will be useful,but WITHOUT ANY WARRANTY; without even
    the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the LGPL License
    for more details.

    You should have received a copy of the GNU Lesser General Public License (LGPL) along with VPNET.
    If not, see <http://www.gnu.org/licenses/>. 
*/
#endregion

using System;
using System.IO;
using VpNet.Abstract;
using VpNet.Extensions;
using VpNet.PluginFramework;

namespace VpNet.Plugins
{
    /// <summary>
    /// Example of plugin 
    /// </summary>
    public class LoggingPlugin : BaseInstancePlugin
    {
        /// <summary>
        /// Initializes the plugin as a child plugin of the main instance.
        /// The plugin assumes the masterbot has already entered a world.
        /// </summary>
        /// <param name="baseInstance">The base instance.</param>
        public override void InitializePlugin(BaseInstanceEvents<World> baseInstance)
        {
            Vp = new Instance(baseInstance);
            Vp.OnAvatarEnter += OnAvatarEnter;
            Vp.OnAvatarLeave += OnAvatarLeave;
            Vp.OnChatMessage += OnChatMessage;
            Vp.OnObjectChange += Vp_OnObjectChange;
            Vp.OnObjectClick += Vp_OnObjectClick;
            Vp.OnObjectCreate += Vp_OnObjectCreate;
            Vp.OnObjectDelete += Vp_OnObjectDelete;
            Vp.OnWorldList += Vp_OnWorldList;
        }

        string LogName(string eventType)
        {
            return Path.Combine(Vp.Configuration.World.Name,eventType, DateTime.Now.ToString("yyyyMMdd") + ".xml");
        }


        void Vp_OnWorldList(Instance sender, WorldListEventArgs args)
        {
            args.Serialize().AppendTextFile(LogName("OnWorldList"));
        }

        void Vp_OnObjectDelete(Instance sender, ObjectDeleteArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnObjectDelete"));
        }

        void Vp_OnObjectCreate(Instance sender, ObjectCreateArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnObjectCreate"));
        }

        void Vp_OnObjectClick(Instance sender, ObjectClickArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnObjectClick"));
        }

        void Vp_OnObjectChange(Instance sender, ObjectChangeArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnObjectChange"));
        }

        void OnChatMessage(Instance sender, ChatMessageEventArgsT<Avatar<Vector3>, ChatMessage, Vector3, Color> args)
        {
            args.Serialize().AppendTextFile(LogName("OnChatMessage"));
        }

        void OnAvatarLeave(Instance sender, AvatarLeaveEventArgsT<Avatar<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnAvatarLeave"));
        }

        void OnAvatarEnter(Instance sender, AvatarEnterEventArgsT<Avatar<Vector3>, Vector3> args)
        {
            args.Serialize().AppendTextFile(LogName("OnAvatarEnter"));
        }

        override public PluginDescription Description
        {
            get
            {
                return new PluginDescription()
                {
                    Name = "log",
                    Description = "This plugin allows you to log xml event messages."
                };
            }
        }

        public override void Unload()
        {
            Vp.OnAvatarEnter -= OnAvatarEnter;
            Vp.OnAvatarLeave -= OnAvatarLeave;
            Vp.OnChatMessage -= OnChatMessage;
            Vp.OnObjectChange -= Vp_OnObjectChange;
            Vp.OnObjectClick -= Vp_OnObjectClick;
            Vp.OnObjectCreate -= Vp_OnObjectCreate;
            Vp.OnObjectDelete -= Vp_OnObjectDelete;
            Vp.OnWorldList -= Vp_OnWorldList;
        }
    }
}
