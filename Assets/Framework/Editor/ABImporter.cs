// **********************************************************************
/// <summary>
// 作者(Author):                    左慈
// 创建时间(CreateTime):             2017-04-14 17:59:11
// 模块描述(Module description):     资源导入时调用，用于自动设置资源属性
/// </summary>
// **********************************************************************
using UnityEngine;
using UnityEditor;
using System.IO;

public class ABImporter : AssetPostprocessor
{
	private static string[] TextureFolders =
	{
		"atlas",
		"Resources",
	};

	private static string[] ABFolders =
	{
		"atlas",
		"luaexport"
	};

	/// <summary>
	/// 模型导入之前调用
	/// </summary>
    public void OnPreprocessModel()
    {
        
    }

	/// <summary>
	/// 模型导入之前调用
	/// </summary> 
    public void OnPostprocessModel(GameObject go)
    {  
        
    }

	/// <summary>
	/// 纹理导入之前调用，针对入到的纹理进行设置
	/// </summary>
	void OnPreprocessTexture()
	{
		SetImageInspector();
    }

	/// <summary>
	/// 纹理导入之前调用，针对入到的纹理进行设置
	/// </summary>
	public void OnPostprocessTexture(Texture2D tex)
    {  
        
    }

	/// <summary>
	/// 声音导入之前调用
	/// </summary>
    public void OnPreprocessAudio()
    {
        
    }

	/// <summary>
	/// 声音导入之前调用
	/// </summary>
    public void OnPostprocessAudio(AudioClip clip)
    {
    
    }

	/// <summary>
	/// 设置图片属性
	/// </summary>
	void SetImageInspector()
	{
		string fileName = System.IO.Path.GetFileName(assetPath);
		bool canset = false;
		for (int i = 0; i < TextureFolders.Length; i++)
		{
			var setpath = TextureFolders[i];
			if (assetPath.Contains(setpath))
			{
				canset = true;
				break;
			}
		}

		if (!canset)
		{
			return;
		}

		// 自动设置类型
        TextureImporter tImport = assetImporter as TextureImporter;
        tImport.textureType = TextureImporterType.Sprite;

		if (fileName.Contains("font_"))
		{
			tImport.spriteImportMode = SpriteImportMode.Multiple;
		}
        else
		{
			tImport.spriteImportMode = SpriteImportMode.Single;
		}

		// 自动设置打包tag
        string dirName = System.IO.Path.GetDirectoryName(assetPath);
        string folderStr = System.IO.Path.GetFileName(dirName);
		bool isbg = (fileName.Contains("_bg") || fileName.Contains("bg_"));
		bool isrepeat = (fileName.Contains("repeat_"));
		bool bCancelPackingTag = (assetPath.Contains("Resources") || fileName.Contains("font_"));
		tImport.spritePackingTag = ((isbg || isrepeat || bCancelPackingTag) ? string.Empty : folderStr.ToLower());

		tImport.alphaIsTransparency = !isbg;

        tImport.spritePixelsPerUnit = 100;

        tImport.mipmapEnabled = false;

		tImport.wrapMode = (isrepeat ? TextureWrapMode.Repeat : TextureWrapMode.Clamp);
        
        tImport.maxTextureSize = 2048;
        tImport.textureCompression = TextureImporterCompression.CompressedHQ;

		// PC
        TextureImporterPlatformSettings s1 = new TextureImporterPlatformSettings();
        s1.overridden = true;
        s1.name = "Standalone";
		s1.maxTextureSize = 2048;

        // IOS
        TextureImporterPlatformSettings s2 = new TextureImporterPlatformSettings();
		s2.overridden = true;
        s2.name = "iPhone";
        s2.maxTextureSize = 2048;
        s2.compressionQuality = 100;

        // Android
        TextureImporterPlatformSettings s3 = new TextureImporterPlatformSettings();
		s3.overridden = true;
        s3.name = "Android";
		s3.maxTextureSize = 2048;
        
		if (isbg)
		{
			s1.format = TextureImporterFormat.DXT1;
			s2.format = TextureImporterFormat.RGB16;
			s3.format = TextureImporterFormat.DXT1;
		}
		else
		{
			s1.format = TextureImporterFormat.DXT5;
			s2.format = TextureImporterFormat.ASTC_RGBA_8x8;
			s3.format = TextureImporterFormat.DXT5;
		}

		tImport.SetPlatformTextureSettings(s1);
		tImport.SetPlatformTextureSettings(s2);
		tImport.SetPlatformTextureSettings(s3);
    }

	/// <summary>
	/// 所有的资源的导入，删除，移动，都会调用此方法，注意，这个方法是static的
	/// </summary>
	public static void OnPostprocessAllAssets(string[]importedAsset, string[] deletedAssets, string[] movedAssets, string[]movedFromAssetPaths)
	{
		foreach (string file in importedAsset)
		{
            SetImportAssetBundleName(file);
        }

		foreach (string file in deletedAssets)
		{
            SetDeleteAsset(file);
        }

		foreach (string file in movedAssets)
		{
			AssetDatabase.ImportAsset(file);
			SetImportAssetBundleName(file);
		}

		foreach (string file in movedFromAssetPaths)
		{
            SetDeleteAsset(file);
        }
	}

	/// 导入文件时添加AssetBundle名字
	static void SetImportAssetBundleName(string file)
	{
		bool canset = false;
		for (int i = 0; i < ABFolders.Length; i++)
		{
			var setpath = ABFolders[i];
			if (file.Contains(setpath))
			{
				canset = true;
				break;
			}
		}

		if (!canset)
		{
			return;
		}

        string abName = string.Empty;
		if (file.IndexOf("luascript") != -1)
		{
			if (file.EndsWith(".bytes") || file.EndsWith(".txt"))
			{
				abName = "luascript.dat";
			}
		}
		else
		{
			if (file.EndsWith(".prefab") ||
				file.EndsWith(".png") ||
				file.EndsWith(".jpg") ||
				file.EndsWith(".mp3") ||
				file.EndsWith(".ogg") ||
				file.EndsWith(".wav") ||
				file.EndsWith(".anim") ||
				file.EndsWith(".controller") ||
				file.EndsWith(".ttf") ||
				file.EndsWith(".mat") ||
				file.EndsWith(".fontsettings") ||
				file.EndsWith(".asset") ||
				file.EndsWith(".txt") ||
				file.EndsWith(".json") ||
				file.EndsWith(".fbx"))
			{
				abName = System.IO.Path.GetDirectoryName(file);
				abName = System.IO.Path.GetFileName(abName);
				if (!abName.EndsWith(".dat"))
				{
					abName += ".dat";
				}
			}
			else
			{
				return;
			}
		}
        
		AssetImporter importer = AssetImporter.GetAtPath(file);
		if (!string.IsNullOrEmpty(abName))
		{
			if (!importer.assetBundleName.Equals(abName))
			{
                importer.assetBundleName = abName;
            }
        }
		else
		{
            importer.assetBundleName = null;
        }
	}

	// 删除文件
	static void SetDeleteAsset(string file)
	{
        string metaFile = file + ".meta";
		if (File.Exists(metaFile))
		{
            File.Delete(metaFile);
        }
    }
}

