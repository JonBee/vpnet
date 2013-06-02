﻿using VpNet.Abstract;

namespace VpNet
{
    public class Instance : BaseInstanceT<Instance,
        Avatar<Vector3>, 
        Color, 
        Friend, 
        RcDefault, 
        TerrainCell, 
        TerrainNode, 
        TerrainTile,
        Vector3, 
        VpObject<Vector3>, 
        World, 
        WorldAttributes,
        Cell,
        ChatMessage,
        Terrain,
        Universe,

        AvatarChangeEventArgsT<Avatar<Vector3>,Vector3>,
        AvatarEnterEventArgsT<Avatar<Vector3>,Vector3>,
        AvatarLeaveEventArgsT<Avatar<Vector3>,Vector3>,
        QueryCellResultArgsT<VpObject<Vector3>, Vector3>,
        QueryCellEndArgs,
        ChatMessageEventArgsT<Avatar<Vector3>,ChatMessage,Vector3,Color>,
        FriendAddCallbackEventArgs,
        FriendDeleteCallbackEventArgs,
        FriendsGetCallbackEventArgs,
        TerrainNodeEventArgs,
        UniverseDisconnectEventArgs,
        ObjectChangeArgsT<Avatar<Vector3>,VpObject<Vector3>,Vector3>,
        ObjectChangeCallbackArgsT<RcDefault,VpObject<Vector3>,Vector3>,
        ObjectClickArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3>,
        ObjectCreateArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3>,
        ObjectCreateCallbackArgsT<RcDefault, VpObject<Vector3>, Vector3>,
        ObjectDeleteArgsT<Avatar<Vector3>, VpObject<Vector3>, Vector3>,
        ObjectDeleteCallbackArgsT<RcDefault, VpObject<Vector3>, Vector3>,
        WorldDisconnectEventArgs,
        WorldListEventArgs,
        WorldSettingsChangedEventArgs
        >

   
       
    {
        public Instance()
        {
            Implementor = this;
        }
    }
}