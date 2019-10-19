﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace NonVisuals.StreamDeck
{
    public class StreamDeckLayerHandler
    {
        private List<StreamDeckLayer> _layerList = new List<StreamDeckLayer>();
        private const string SEPARATOR_CHARS = "\\o/";
        private const string HOME_LAYER_ID = "*";

        public StreamDeckLayerHandler()
        {
        }

        public string ExportLayers()
        {
            var stringBuilder = new StringBuilder();
            var layers = "Layers{";
            foreach (var layer in _layerList)
            {
                if (layer.IsHomeLayer)
                {
                    layers = layers + "|*" + layer.Name;
                }
                else
                {
                    layers = layers + "|" + layer.Name;
                }
            }
            layers += "}";
            return layers;
        }

        private void Add(bool isActive, bool isHomeLayer, string layerName)
        {
            var found = false;
            
            foreach (var layer in _layerList)
            {
                if (layer.Name == layerName)
                {
                    found = true;
                }
            }

            if (!found)
            {
                var layer = new StreamDeckLayer();
                layer.Name = layerName;
                layer.IsHomeLayer = isHomeLayer;
                layer.IsActive = isActive;
                _layerList.Add(layer);
            }
        }

        public void AddLayer(string layerName)
        {
            if (layerName.Contains(SEPARATOR_CHARS))
            {
                //Setting loaded, includes HID Instance and may contain many layers separated by |
                var layers = layerName.Split(new[] {SEPARATOR_CHARS}, StringSplitOptions.RemoveEmptyEntries)[0];
                layers = layers.Replace("Layers{", "").Replace("}", "");
                var layerArray = layers.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in layerArray)
                {
                    if (s.Contains(HOME_LAYER_ID))
                    {
                        Add(false, true, s.Replace(HOME_LAYER_ID,""));
                    }
                    else
                    {
                        Add(false, false, s);
                    }
                }
            }
            else
            {
                Add(false, false, layerName);
            }
        }

        public void AddLayer(StreamDeckLayer streamDeckLayer)
        {
            if (!LayerList.Contains(streamDeckLayer) && streamDeckLayer != null)
            {
                LayerList.Add(streamDeckLayer);
            }
        }

        public void DeleteLayer(string layerName)
        {
            _layerList.RemoveAll(x => x.Name == layerName);
        }

        public List<StreamDeckLayer> LayerList
        {
            get => _layerList;
            set => _layerList = value;
        }

        public void ClearSettings()
        {
            _layerList.Clear();
        }


        public StreamDeckLayer HomeLayer
        {
            get
            {
                foreach (var streamDeckLayer in _layerList)
                {
                    if (streamDeckLayer.IsHomeLayer)
                    {
                        return streamDeckLayer;
                    }
                }

                return null;
            }
        }

        public List<string> GetStreamDeckLayerNames()
        {
            var result = new List<string>();

            foreach (var streamDeckLayer in _layerList)
            {
                result.Add(streamDeckLayer.Name);
            }

            return result;
        }

        public StreamDeckButton GetStreamDeckButton(StreamDeckButtonNames streamDeckButtonName, string layerName)
        {

            foreach (var streamDeckLayer in _layerList)
            {
                if (streamDeckLayer.Name == layerName && streamDeckLayer.ContainStreamDeckButton(streamDeckButtonName))
                {
                    return streamDeckLayer.GetStreamDeckButtonName(streamDeckButtonName);
                }
            }
            
            throw new Exception("Button " + streamDeckButtonName + " cannot be found in layer " + layerName + ".");
        }

    }
}
