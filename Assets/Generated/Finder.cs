// ----- AUTO GENERATED CODE - ANY MODIFICATION WILL BE OVERRIDEN ----- //
// ----- GENERATED ON 2020-03-01 10:47:59.090354200 -05:00 ----- //

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
        private static ManageMenus findableManageMenus = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Scripts\Control\ManageMenus.cs, line 7.
        private static Harmony.SceneBundleLoader findableSceneBundleLoader = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Libraries\Harmony\Scripts\Playmode\Scene\SceneBundleLoader.cs, line 12.
        private static SceneBundlesReference findableSceneBundlesReference = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Libraries\Harmony\Scripts\Playmode\Scene\SceneBundlesReference.cs, line 5.
        private static Harmony.PathFinder findablePathFinder = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Libraries\Harmony\Scripts\Playmode\Navigation\PathFinder.cs, line 13.
        private static Harmony.NavigationMesh findableNavigationMesh = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Libraries\Harmony\Scripts\Playmode\Navigation\NavigationMesh.cs, line 12.
        private static Harmony.SqLiteConnectionFactory findableSqLiteConnectionFactory = null; //File C:\Users\LP\Documents\WonderJam2020\Assets\Libraries\Harmony\Scripts\Playmode\Database\SqLiteConnectionFactory.cs, line 13.
    
        public static ManageMenus ManageMenus
        {
            get
            {
                if (!findableManageMenus) findableManageMenus = FindWithTag<ManageMenus>(R.S.Tag.MainController);
                return findableManageMenus;
            }
        }
        
        public static Harmony.SceneBundleLoader SceneBundleLoader
        {
            get
            {
                if (!findableSceneBundleLoader) findableSceneBundleLoader = FindWithTag<Harmony.SceneBundleLoader>(R.S.Tag.MainController);
                return findableSceneBundleLoader;
            }
        }
        
        public static SceneBundlesReference SceneBundlesReference
        {
            get
            {
                if (!findableSceneBundlesReference) findableSceneBundlesReference = FindWithTag<SceneBundlesReference>(R.S.Tag.MainController);
                return findableSceneBundlesReference;
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
        
        public static Harmony.NavigationMesh NavigationMesh
        {
            get
            {
                if (!findableNavigationMesh) findableNavigationMesh = FindWithTag<Harmony.NavigationMesh>(R.S.Tag.NavigationMesh);
                return findableNavigationMesh;
            }
        }
        
        public static Harmony.SqLiteConnectionFactory SqLiteConnectionFactory
        {
            get
            {
                if (!findableSqLiteConnectionFactory) findableSqLiteConnectionFactory = FindWithTag<Harmony.SqLiteConnectionFactory>(R.S.Tag.MainController);
                return findableSqLiteConnectionFactory;
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