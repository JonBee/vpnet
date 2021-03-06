﻿#region Copyright notice
/*
____   ___.__         __               .__    __________                        .__.__                
\   \ /   |__________/  |_ __ _______  |  |   \______   _____ ____________    __| _|__| ______ ____   
 \   Y   /|  \_  __ \   __|  |  \__  \ |  |    |     ___\__  \\_  __ \__  \  / __ ||  |/  ____/ __ \  
  \     / |  ||  | \/|  | |  |  // __ \|  |__  |    |    / __ \|  | \// __ \/ /_/ ||  |\___ \\  ___/  
   \___/  |__||__|   |__| |____/(____  |____/  |____|   (____  |__|  (____  \____ ||__/____  >\___  > 
                                     \/                      \/           \/     \/        \/     \/  
    This file is part of VPNET Version 1.0

    Copyright (c) 2012-2016 CUBE3 (Cit:36)

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

using System.Xml.Serialization;
using VpNet.Abstract;

namespace VpNet.GameExtensions
{
    /// <summary>
    /// Default Event Arguments implementation mapping. You can define your own mappings when implementing VpNet.Abstract.BaseInstanceT
    /// </summary>
    [XmlRoot("OnAvatarChange", Namespace = Global.XmlNsEvent)]
    public class GameAvatarChangeEventArgs : BaseAvatarChangeEventArgs<GameAvatar, Vector3>
    {
        public GameAvatarChangeEventArgs(GameAvatar avatar, GameAvatar avatarPrevious) : base(avatar,avatarPrevious)
        {
        }

        public GameAvatarChangeEventArgs()
        {
            
        }
    }

    /// <summary>
    /// Default Event Arguments implementation mapping. You can define your own mappings when implementing VpNet.Abstract.BaseInstanceT
    /// </summary>
    [XmlRoot("OnAvatarEnter", Namespace = Global.XmlNsEvent)]
    public class GameAvatarEnterEventArgs : BaseAvatarEnterEventArgs<GameAvatar, Vector3>
    {
        //public object Implementor { get; set; }

        public GameAvatarEnterEventArgs(GameAvatar avatar) : base(avatar)
        {
        }

        public GameAvatarEnterEventArgs()
        {
        }

        public override void Initialize()
        {
            Avatar.GameInstance = (GameInstance)Implementor;
        }
    }

    /// <summary>
    /// Default Event Arguments implementation mapping. You can define your own mappings when implementing VpNet.Abstract.BaseInstanceT
    /// </summary>
    [XmlRoot("OnAvatarLeave", Namespace = Global.XmlNsEvent)]
    public class GameAvatarLeaveEventArgs : BaseAvatarLeaveEventArgs<GameAvatar, Vector3>
    {
        public GameAvatarLeaveEventArgs(GameAvatar avatar) : base(avatar) { }
        public GameAvatarLeaveEventArgs() { }

        public override void Initialize()
        {
            Avatar.GameInstance = (GameInstance)Implementor;
        }
    }

    /// <summary>
    /// Default Event Arguments implementation mapping. You can define your own mappings when implementing VpNet.Abstract.BaseInstanceT
    /// </summary>
    [XmlRoot("OnAvatarClick", Namespace = Global.XmlNsEvent)]
    public class GameAvatarClickEventArgs : BaseAvatarClickEventArgs<GameAvatar, Vector3>
    {
        public GameAvatarClickEventArgs(GameAvatar avatar, GameAvatar clickedAvatar, Vector3 worldHit) : base(avatar, clickedAvatar, worldHit) { }
        public GameAvatarClickEventArgs() { }

        public override void Initialize()
        {

            Avatar.GameInstance = (GameInstance)Implementor;
        }
    }
}
