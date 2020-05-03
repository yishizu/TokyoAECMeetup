using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Input;
using Rhino.Input.Custom;

namespace RhinoWPFIntroWorkshop
{
    public class SelectObjects : Command
    {
        static SelectObjects _instance;
        public SelectObjects()
        {
            _instance = this;
        }

        ///<summary>The only instance of the SelectObjects command.</summary>
        public static SelectObjects Instance
        {
            get { return _instance; }
        }

        public override string EnglishName
        {
            get { return "SelectObjects"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            const ObjectType geometryFilter = ObjectType.Surface | ObjectType.PolysrfFilter | ObjectType.Mesh;

            GetObject go = new GetObject();
            go.SetCommandPrompt("Select surfaces, polysurfaces, or meshes");
            go.GeometryFilter = geometryFilter;
            go.GroupSelect = true;
            go.SubObjectSelect = false;
            go.EnableClearObjectsOnEntry(false);
            go.EnableUnselectObjectsOnExit(false);
            go.DeselectAllBeforePostSelect = false;

            bool bHavePreselectedObjects = false;

            for (; ; ) // infinite loop
            {
                GetResult res = go.GetMultiple(1, 0);

                if (res == GetResult.Option)
                {
                    go.EnablePreSelect(false, true);
                    continue;
                }

                else if (res != GetResult.Object)
                    return Result.Cancel;

                if (go.ObjectsWerePreselected)
                {
                    bHavePreselectedObjects = true;
                    go.EnablePreSelect(false, true);
                    continue;
                }

                break;
            }

            
            if (bHavePreselectedObjects)
            {
                for (int i = 0; i < go.ObjectCount; i++)
                {
                    RhinoObject rhinoObject = go.Object(i).Object();
                    if (null != rhinoObject)
                    {
                        rhinoObject.Select(false);
                       
                    }
                        
                }
                doc.Views.Redraw();
            }

            int objectCount = go.ObjectCount;

            List<String> objectTypeList = new List<string>();
            List<String> objectNameList = new List<string>();
            for (int i = 0; i < go.ObjectCount; i++)
            {
                RhinoObject rhinoObject = go.Object(i).Object();
                string objectName = rhinoObject.Name;
                if (null != rhinoObject)
                {
                    objectTypeList.Add(rhinoObject.ObjectType.ToString());
                    objectNameList.Add(objectName);
                }
            }
                

            RhinoApp.WriteLine(string.Format("Select object count = {0}", objectCount));
            for (int i = 0; i < objectTypeList.Count; i++)
            {
                RhinoApp.WriteLine(string.Format("Select object Name : {0}, Type : {1}", objectNameList[i], objectTypeList[i]));
            }
            


            return Result.Success;
        }
    }
}