using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PatkaPlayer
{
    class VolumeControl
    {

        #region Constants
        //This works on 7 an 8 but 8 uses app that process was spowned from
        //private const string AppProcess = "awesomium_process";

        //private const string ProcessName1 = "screamer";
        private static string ProcessName1 = null;

        //private const string ProcessName2 = "YourMainAppNameofEXE";

        #endregion

        /// <summary>
        /// Gets or sets the volume level
        /// </summary>
        public float? Volume
        {
            get
            {
                return GetApplicationVolume();
            }
            set { if (value != null) SetApplicationVolume(value.Value); }
        }

        /// <summary>
        /// Gets or sets the mute indicator.
        /// </summary>
        public bool Mute
        {
            get
            {
                return GetApplicationMute();
            }
            set
            {
                SetApplicationMute(value);
            }
        }

        #region Constructor

        /// <summary>
        /// Creates an instance for controlling the app audio.
        /// </summary>
        public VolumeControl()
        {


        }

        public VolumeControl(string name)
        {
            ProcessName1 = name;
        }


        public static string GetProcessname()
        {

            //ToDo Need a way to check for both names. processName1 and processName2  Windows 8 has both names



            return ProcessName1;

        }


        #endregion

        public static float GetApplicationVolume()
        {

            string appProcess = GetProcessname();

            float level = 0;
            List<ISimpleAudioVolume> volumes = GetVolumeObject(appProcess);
            if (volumes == null || volumes.Count == 0)
                return level;

            foreach (ISimpleAudioVolume volume in volumes)
                volume.GetMasterVolume(out level);
            return level * 100;
        }

        public static bool GetApplicationMute()
        {

            //string AppProcess = GetProcessname();

            List<ISimpleAudioVolume> volumes = GetVolumeObject(GetProcessname());
            bool mute = false;
            if (volumes == null || volumes.Count == 0)
                return mute;

            bool aux;
            foreach (ISimpleAudioVolume volume in volumes)
            {
                volume.GetMute(out aux);
                mute = mute && aux;
            }
            return mute;
        }

        public static void SetApplicationVolume(float level)
        {
            List<ISimpleAudioVolume> volumes = GetVolumeObject(GetProcessname());
            if (volumes == null || volumes.Count == 0)
                return;

            Guid guid = Guid.Empty;
            foreach (ISimpleAudioVolume volume in volumes)
                volume.SetMasterVolume(level / 100, ref guid);
        }

        public static void SetApplicationMute(bool mute)
        {
            List<ISimpleAudioVolume> volumes = GetVolumeObject(GetProcessname());
            if (volumes == null || volumes.Count == 0)
                return;

            Guid guid = Guid.Empty;
            foreach (ISimpleAudioVolume volume in volumes)
                volume.SetMute(mute, ref guid);
        }

        private static List<ISimpleAudioVolume> GetVolumeObject(string name)
        {
            // get the speakers (1st render + multimedia) device
            IMMDeviceEnumerator deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
            IMMDevice speakers;
            deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);

            // activate the session manager. we need the enumerator
            Guid IID_IAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
            object o;
            speakers.Activate(ref IID_IAudioSessionManager2, 0, IntPtr.Zero, out o);
            IAudioSessionManager2 mgr = (IAudioSessionManager2)o;

            // enumerate sessions for on this device
            IAudioSessionEnumerator sessionEnumerator;
            mgr.GetSessionEnumerator(out sessionEnumerator);
            int count;
            sessionEnumerator.GetCount(out count);
            List<ISimpleAudioVolume> volumeControls = new List<ISimpleAudioVolume>();
            for (int i = 0; i < count; i++)
            {
                IAudioSessionControl ctl;
                IAudioSessionControl2 ctl2;

                sessionEnumerator.GetSession(i, out ctl);

                ctl2 = ctl as IAudioSessionControl2;

                string sout1 = "";
                string sout2 = "";
                if (ctl2 != null)
                {
                    ctl2.GetSessionIdentifier(out sout1);
                    ctl2.GetSessionInstanceIdentifier(out sout2);
                }

                if (sout1.Contains(GetProcessname()) || sout2.Contains(GetProcessname()))
                {
                    volumeControls.Add(ctl as ISimpleAudioVolume);
                }
            }
            return volumeControls;
        }
    }

    [ComImport]
    [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
    internal class MMDeviceEnumerator
    {
    }

    internal enum EDataFlow
    {
        eRender,
        eCapture,
        eAll,
        EDataFlow_enum_count
    }

    internal enum ERole
    {
        eConsole,
        eMultimedia,
        eCommunications,
        ERole_enum_count
    }

    [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IMMDeviceEnumerator
    {
        int NotImpl1();

        [PreserveSig]
        int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppDevice);

        // the rest is not implemented
    }

    [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IMMDevice
    {
        [PreserveSig]
        int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);

        // the rest is not implemented
    }

    [Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioSessionManager2
    {
        int NotImpl1();
        int NotImpl2();

        [PreserveSig]
        int GetSessionEnumerator(out IAudioSessionEnumerator SessionEnum);

        // the rest is not implemented
    }

    [Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioSessionEnumerator
    {
        [PreserveSig]
        int GetCount(out int SessionCount);

        [PreserveSig]
        int GetSession(int SessionCount, out IAudioSessionControl Session);
    }

    [Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioSessionControl
    {
        int NotImpl1();

        [PreserveSig]
        int GetDisplayName([MarshalAs(UnmanagedType.LPWStr)] out string pRetVal);

        // the rest is not implemented
    }

    [Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISimpleAudioVolume
    {
        [PreserveSig]
        int SetMasterVolume(float fLevel, ref Guid EventContext);

        [PreserveSig]
        int GetMasterVolume(out float pfLevel);

        [PreserveSig]
        int SetMute(bool bMute, ref Guid EventContext);

        [PreserveSig]
        int GetMute(out bool pbMute);
    }


    public enum AudioSessionState
    {
        AudioSessionStateInactive = 0,
        AudioSessionStateActive = 1,
        AudioSessionStateExpired = 2
    }

    public enum AudioSessionDisconnectReason
    {
        DisconnectReasonDeviceRemoval = 0,
        DisconnectReasonServerShutdown = (DisconnectReasonDeviceRemoval + 1),
        DisconnectReasonFormatChanged = (DisconnectReasonServerShutdown + 1),
        DisconnectReasonSessionLogoff = (DisconnectReasonFormatChanged + 1),
        DisconnectReasonSessionDisconnected = (DisconnectReasonSessionLogoff + 1),
        DisconnectReasonExclusiveModeOverride = (DisconnectReasonSessionDisconnected + 1)
    }

    [Guid("24918ACC-64B3-37C1-8CA9-74A66E9957A8"),
InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioSessionEvents
    {
        [PreserveSig]
        int OnDisplayNameChanged([MarshalAs(UnmanagedType.LPWStr)] string NewDisplayName, Guid EventContext);
        [PreserveSig]
        int OnIconPathChanged([MarshalAs(UnmanagedType.LPWStr)] string NewIconPath, Guid EventContext);
        [PreserveSig]
        int OnSimpleVolumeChanged(float NewVolume, bool newMute, Guid EventContext);
        [PreserveSig]
        int OnChannelVolumeChanged(UInt32 ChannelCount, IntPtr NewChannelVolumeArray, UInt32 ChangedChannel, Guid EventContext);
        [PreserveSig]
        int OnGroupingParamChanged(Guid NewGroupingParam, Guid EventContext);
        [PreserveSig]
        int OnStateChanged(AudioSessionState NewState);
        [PreserveSig]
        int OnSessionDisconnected(AudioSessionDisconnectReason DisconnectReason);
    }

    [Guid("BFB7FF88-7239-4FC9-8FA2-07C950BE9C6D"),
   InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioSessionControl2
    {
        [PreserveSig]
        int GetState(out AudioSessionState state);
        [PreserveSig]
        int GetDisplayName([Out(), MarshalAs(UnmanagedType.LPWStr)] out string name);
        [PreserveSig]
        int SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string value, Guid EventContext);
        [PreserveSig]
        int GetIconPath([Out(), MarshalAs(UnmanagedType.LPWStr)] out string Path);
        [PreserveSig]
        int SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, Guid EventContext);
        [PreserveSig]
        int GetGroupingParam(out Guid GroupingParam);
        [PreserveSig]
        int SetGroupingParam(Guid Override, Guid Eventcontext);
        [PreserveSig]
        int RegisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
        [PreserveSig]
        int UnregisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
        [PreserveSig]
        int GetSessionIdentifier([Out(), MarshalAs(UnmanagedType.LPWStr)] out string retVal);
        [PreserveSig]
        int GetSessionInstanceIdentifier([Out(), MarshalAs(UnmanagedType.LPWStr)] out string retVal);
        [PreserveSig]
        int GetProcessId(out UInt32 retvVal);
        [PreserveSig]
        int IsSystemSoundsSession();
        [PreserveSig]
        int SetDuckingPreference(bool optOut);
    }
}