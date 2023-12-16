#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using jellyfin_ani_sync.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace jellyfin_ani_sync {
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer) {
            Instance = this;
        }

        public override string Name => "Ani-Sync";
        public override Guid Id => Guid.Parse("e2c780d0-9158-4bd8-bd01-8c16d05bb674");
        public override string Description => "Synchronize anime watch status between Jellyfin and anime tracking sites.";
        public PluginConfiguration PluginConfiguration => Configuration;
        public static Plugin? Instance { get; private set; }

        public IEnumerable<PluginPageInfo> GetPages() {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = Name,
                    EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.ConfigPage.html"
                },
                new PluginPageInfo {
                    Name = "ConfigPageJs",
                    EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.ConfigPageJs.js"
                }
            };
        }
    }
}