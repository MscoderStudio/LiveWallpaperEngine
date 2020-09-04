﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Giantapp.LiveWallpaper.Engine
{
    public class ScreenOption
    {
        public enum ActionWhenMaximized
        {
            Pause,
            Stop,
            Play
        }
        /// <summary>
        /// 最大化时壁纸是否暂停，停止等
        /// </summary>
        public ActionWhenMaximized WhenAppMaximized { get; set; }
        /// <summary>
        /// 所影响的屏幕
        /// </summary>
        public string Screen { get; set; }
    }
    /// <summary>
    /// api 提供的选项
    /// </summary>
    public class LiveWallpaperOptions
    {
        /// <summary>
        /// explorer挂了是否重启
        /// </summary>
        public bool AutoRestartWhenExplorerCrash { get; set; }
        /// <summary>
        /// 屏幕参数
        /// </summary>
        public List<ScreenOption> ScreenOptions { get; set; }
        /// <summary>
        /// 壁纸音源来源哪块屏幕， -1 表示禁用
        /// </summary>
        public string AudioScreen { get; set; }
        public List<string> AudioScreenOptions
        {
            get
            {
                return WallpaperApi.Screens.ToList();
            }
        }
        /// <summary>
        /// 屏幕最大化是否影响所有屏幕
        /// </summary>
        public bool AppMaximizedEffectAllScreen { get; set; }
        /// <summary>
        /// 转发鼠标事件
        /// </summary>
        public bool ForwardMouseEvent { get; set; } = true;

        private string _externalPlayerFolder;
        /// <summary>
        /// 视频播放器，浏览器等存储位置
        /// </summary>
        public string ExternalPlayerFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_externalPlayerFolder))
                {
                    //默认位置
                    var assembly = Assembly.GetEntryAssembly();
                    string appDir = Path.GetDirectoryName(assembly.Location);
                    return $@"{appDir}\players\";
                }

                return _externalPlayerFolder;
            }
            set => _externalPlayerFolder = value;
        }
    }
}
