// ----- AUTO GENERATED CODE - ANY MODIFICATION WILL BE OVERRIDEN ----- //
// ----- GENERATED ON 2020-02-28 02:13:18.737124 -05:00 ----- //

/*
 * To add an object to the Finder, add a "Findable" attribute to the class :
 *
 * For example :
 *
 *   [Findable("MainController")]
 *   public class MyClass : MonoBehaviour
 *   {
 *   }
 *
 * You can also use the generated constants. For example :
 *
 *   [Findable(R.S.Tag.MainController)]
 *   public class MyClass : MonoBehaviour
 *   {
 *   }
 *
 * Please note that the "Findable" attribute is defined in this file.
 */

using System;
using UnityEngine;

namespace Harmony
{
    public static class Finder
    {
        private static Harmony.SqLiteConnectionFactory findableSqLiteConnectionFactory = null; //File C:\Users\lphud\Documents\Projects\WonderjamUQACH2020\WonderjamUQACH2020\Assets\Libraries\Harmony\Scripts\Playmode\Database\SqLiteConnectionFactory.cs, line 13.
        private static Harmony.NavigationMesh findableNavigationMesh = null; //File C:\Users\lphud\Documents\Projects\WonderjamUQACH2020\WonderjamUQACH2020\Assets\Libraries\Harmony\Scripts\Playmode\Navigation\NavigationMesh.cs, line 12.
        private static Harmony.PathFinder findablePathFinder = null; //File C:\Users\lphud\Documents\Projects\WonderjamUQACH2020\WonderjamUQACH2020\Assets\Libraries\Harmony\Scripts\Playmode\Navigation\PathFinder.cs, line 13.
    
        public static Harmony.SqLiteConnectionFactory SqLiteConnectionFactory
        {
            get
            {
                if (!findableSqLiteConnectionFactory) findableSqLiteConnectionFactory = FindWithTag<Harmony.SqLiteConnectionFactory>(R.S.Tag.GameController);
                return findableSqLiteConnectionFactory;
            }
        }
        
        public static Harmony.NavigationMesh NavigationMesh
        {
            get
            {
                if (!findableNavigationMesh) findableNavigationMesh = FindWithTag<Harmony.NavigationMesh>(R.S.Tag.NavigationMesh);
                return findableNavigationMesh;
            }
        }
        
        public static Harmony.PathFinder PathFinder
        {
            get
            {
                if (!findablePathFinder) findablePathFinder = FindWithTag<Harmony.PathFinder>(R.S.Tag.NavigationMesh);
                return findablePathFinder;
            }
        }
        

        private static T FindWithTag<T>(string tag)
        {
            return GameObject.FindWithTag(tag).GetComponent<T>();
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class FindableAttribute : PropertyAttribute
    {
        public string Tag { get; }

        public FindableAttribute(string tag)
        {
            Tag = tag;
        }
    }
}