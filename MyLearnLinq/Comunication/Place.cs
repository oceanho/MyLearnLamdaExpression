﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearnLinq.Comunication
{
    public class Place
    {
        // Properties.
        public string Name { get; private set; }
        public string State { get; private set; }
        public PlaceType PlaceType { get; private set; }

        // Constructor.
        internal Place(string name,
                        string state,
                        PlaceType placeType)
        {
            Name = name;
            State = state;
            PlaceType = placeType;
        }

        public override string ToString()
        {
            return $"Name:{Name},State:{State},PlaceType:{PlaceType}";
        }
    }

    public enum PlaceType
    {
        Unknown,
        AirRailStation,
        BayGulf,
        CapePeninsula,
        CityTown,
        HillMountain,
        Island,
        Lake,
        OtherLandFeature,
        OtherWaterFeature,
        ParkBeach,
        PointOfInterest,
        River
    }
}
