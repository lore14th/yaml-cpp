project "yaml"
	kind "StaticLib"
	language "C++"
	cppdialect "C++17"
	staticruntime "on"
	
	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files
	{
		"include/**.h",

		"src/**.h",
		"src/**.cpp",
	}

	includedirs
	{
		"include"
	}

	defines 
	{
		--"_CRT_SECURE_NO_WARNINGS"
	}
	
	filter "system:windows"
		systemversion "latest"

	filter "configurations:Debug"
		runtime "Debug"
		symbols "on"	-- debug version --

	filter "configurations:Release"
		runtime "Release"
		optimize "on"	-- release version --
