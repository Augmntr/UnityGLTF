﻿using System;
using Newtonsoft.Json;

namespace GLTF
{
    /// <summary>
    /// Texture sampler properties for filtering and wrapping modes.
    /// </summary>
    [Serializable]
    public class GLTFSampler
    {
        /// <summary>
        /// Magnification filter.
        /// Valid values correspond to WebGL enums: `9728` (NEAREST) and `9729` (LINEAR).
        /// </summary>
        public GLTFMagFilterMode MagFilter = GLTFMagFilterMode.Linear;

        /// <summary>
        /// Minification filter. All valid values correspond to WebGL enums.
        /// </summary>
        public GLTFMinFilterMode MinFilter = GLTFMinFilterMode.NearestMipmapLinear;

        /// <summary>
        /// s wrapping mode.  All valid values correspond to WebGL enums.
        /// </summary>
        public GLTFWrapMode WrapS = GLTFWrapMode.Repeat;

        /// <summary>
        /// t wrapping mode.  All valid values correspond to WebGL enums.
        /// </summary>
        public GLTFWrapMode WrapT = GLTFWrapMode.Repeat;

        public static GLTFSampler Deserialize(GLTFRoot root, JsonTextReader reader)
        {
            var sampler = new GLTFSampler();
            
            while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
            {
                var curProp = reader.Value.ToString();

                switch (curProp)
                {
                    case "magFilter":
                        sampler.MagFilter = (GLTFMagFilterMode) reader.ReadAsInt32();
                        break;
                    case "minFilter":
                        sampler.MinFilter = (GLTFMinFilterMode)reader.ReadAsInt32();
                        break;
                    case "wrapS":
                        sampler.WrapS = (GLTFWrapMode)reader.ReadAsInt32();
                        break;
                    case "wrapT":
                        sampler.WrapT = (GLTFWrapMode)reader.ReadAsInt32();
                        break;
                    case "extensions":
                    case "extras":
                    default:
                        reader.Read();
                        break;
                }
            }

            return sampler;
        }
    }

    /// <summary>
    /// Magnification filter mode.
    /// </summary>
    public enum GLTFMagFilterMode
    {
        Nearest = 9728,
        Linear = 9729,
    }

    /// <summary>
    /// Minification filter mode.
    /// </summary>
    public enum GLTFMinFilterMode
    {
        Nearest = 9728,
        Linear = 9729,
        NearestMipmapNearest = 9984,
        LinearMipmapNearest = 9985,
        NearestMipmapLinear = 9986,
        LinearMipmapLinear = 9987
    }

    /// <summary>
    /// Texture wrap mode.
    /// </summary>
    public enum GLTFWrapMode
    {
        ClampToEdge = 33071,
        MirroredRepeat = 33648,
        Repeat = 10497
    }
}
