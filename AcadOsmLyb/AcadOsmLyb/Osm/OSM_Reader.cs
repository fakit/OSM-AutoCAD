using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using OsmSharp;
using OsmSharp.Streams;




namespace AcadOsmLyb
{
    public class OSM_Reader
    {
        private FileStream sourceFile;
        public OsmSharp.Streams.PBFOsmStreamSource PBFStream;
        public Dictionary<KeyValuePair<string, string>, List<OsmSharp.Complete.CompleteWay>> tagWayNodes;

        public OSM_Reader(string filename, Dictionary<string, string> tags)
        {
            sourceFile = File.OpenRead(filename);
            PBFStream = new OsmSharp.Streams.PBFOsmStreamSource(sourceFile);
            tagWayNodes = new Dictionary<KeyValuePair<string, string>, List<OsmSharp.Complete.CompleteWay>>();
            foreach (var tag in tags)
            {

                List<OsmSharp.Complete.CompleteWay> wayNodes = getWaysOfATag(PBFStream,  tag.Value,tag.Key);

                tagWayNodes.Add(tag, wayNodes);
            }
        }

        private List<OsmSharp.Complete.CompleteWay> getWaysOfATag(PBFOsmStreamSource source, String key, String value)
        {
            var osmWays = from osmGeo in PBFStream
                          where osmGeo.Type == OsmGeoType.Node ||
                          (osmGeo.Type == OsmGeoType.Way && osmGeo.Tags.Contains(key, value))
                          select osmGeo;
            var completeWays = osmWays.ToComplete();
            List<OsmSharp.Complete.CompleteWay> wayNodes = new List<OsmSharp.Complete.CompleteWay>();
            foreach (var osmWay in completeWays)
            {
                try
                {
                    if (osmWay.Type == OsmGeoType.Way)
                    {
                        OsmSharp.Complete.CompleteWay completeWay = (OsmSharp.Complete.CompleteWay)osmWay;
                        wayNodes.Add(completeWay);
                    }
                }
                catch
                {

                }
            }
            return wayNodes;
        }

       

    }
}
