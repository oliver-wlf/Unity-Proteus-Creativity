using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Collections;
using Didimo.Core.Config;
using Didimo.Core.Utility;




namespace Didimo.Core.Utility
{
    /**
     * Copyright (c)  
     * @file   :EditorRenderToTexture.cs
     * @Author : ()
     * @date   :
     * @brief  :summary
     *
     * description
     */

    public class RenderToTexture
    {
        public static byte[,] bitfont = new byte[,]{{16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,126,129,165,129,129,189,153,129,129,126,0,0,0},
{0,0,0,126,255,219,255,255,195,231,255,255,126,0,0,0},
{0,0,0,0,0,108,254,254,254,254,124,56,16,0,0,0},
{0,0,0,0,0,16,56,124,254,124,56,16,0,0,0,0},
{0,0,0,0,24,60,60,231,231,231,24,24,60,0,0,0},
{0,0,0,0,24,60,126,255,255,126,24,24,60,0,0,0},
{0,0,0,0,0,0,0,24,60,60,24,0,0,0,0,0},
{0,255,255,255,255,255,255,231,195,195,231,255,255,255,255,255},
{255,0,0,0,0,0,60,102,66,66,102,60,0,0,0,0},
{0,255,255,255,255,255,195,153,189,189,153,195,255,255,255,255},
{255,0,0,30,14,26,50,120,204,204,204,204,120,0,0,0},
{0,0,0,60,102,102,102,102,60,24,126,24,24,0,0,0},
{0,0,0,63,51,63,48,48,48,48,112,240,224,0,0,0},
{0,0,0,127,99,127,99,99,99,99,103,231,230,192,0,0},
{0,0,0,0,24,24,219,60,231,60,219,24,24,0,0,0},
{0,0,128,192,224,240,248,254,248,240,224,192,128,0,0,0},
{0,0,2,6,14,30,62,254,62,30,14,6,2,0,0,0},
{0,0,0,24,60,126,24,24,24,126,60,24,0,0,0,0},
{0,0,0,102,102,102,102,102,102,102,0,102,102,0,0,0},
{0,0,0,127,219,219,219,123,27,27,27,27,27,0,0,0},
{0,0,124,198,96,56,108,198,198,108,56,12,198,124,0,0},
{0,0,0,0,0,0,0,0,0,254,254,254,254,0,0,0},
{0,0,0,24,60,126,24,24,24,126,60,24,126,0,0,0},
{0,0,0,24,60,126,24,24,24,24,24,24,24,0,0,0},
{0,0,0,24,24,24,24,24,24,24,126,60,24,0,0,0},
{0,0,0,0,0,0,24,12,254,12,24,0,0,0,0,0},
{0,0,0,0,0,0,48,96,254,96,48,0,0,0,0,0},
{0,0,0,0,0,0,0,192,192,192,254,0,0,0,0,0},
{0,0,0,0,0,0,40,108,254,108,40,0,0,0,0,0},
{0,0,0,0,0,16,56,56,124,124,254,254,0,0,0,0},
{0,0,0,0,0,254,254,124,124,56,56,16,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,56,56,56,56,56,56,0,56,56,0,0,0,0},
{0,0,99,99,99,34,0,0,0,0,0,0,0,0,0,0},
{0,0,0,54,54,127,54,54,54,127,54,54,0,0,0,0},
{0,8,8,62,97,112,60,30,7,3,67,62,8,8,0,0},
{0,0,0,97,147,103,14,28,56,112,230,201,134,0,0,0},
{0,0,0,60,98,242,124,121,154,140,142,119,0,0,0,0},
{0,0,48,48,48,96,0,0,0,0,0,0,0,0,0,0},
{0,0,0,12,24,48,48,48,48,48,24,12,0,0,0,0},
{0,0,0,24,12,6,6,6,6,6,12,24,0,0,0,0},
{0,0,0,0,0,102,60,255,60,102,0,0,0,0,0,0},
{0,0,0,0,24,24,24,255,24,24,24,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,24,24,24,48,0,0,0},
{0,0,0,0,0,0,0,0,255,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,24,24,0,0,0,0},
{0,0,0,1,3,6,12,24,48,96,192,128,0,0,0,0},
{0,0,0,60,98,225,225,225,225,225,98,60,0,0,0,0},
{0,0,0,12,28,60,28,28,28,28,28,28,0,0,0,0},
{0,0,0,126,131,7,14,28,56,112,224,255,0,0,0,0},
{0,0,0,124,134,7,6,56,6,7,134,124,0,0,0,0},
{0,0,0,6,14,30,46,78,142,255,14,14,0,0,0,0},
{0,0,0,126,64,64,124,6,135,135,70,60,0,0,0,0},
{0,0,0,62,97,224,252,226,225,225,98,60,0,0,0,0},
{0,0,0,255,1,3,7,14,28,56,112,112,0,0,0,0},
{0,0,0,62,97,241,250,126,95,143,135,126,0,0,0,0},
{0,0,0,60,70,135,135,71,63,7,134,124,0,0,0,0},
{0,0,0,0,24,24,0,0,24,24,0,0,0,0,0,0},
{0,0,0,0,24,24,0,0,0,24,24,48,0,0,0,0},
{0,0,0,6,12,24,48,96,48,24,12,6,0,0,0,0},
{0,0,0,0,0,0,126,0,0,126,0,0,0,0,0,0},
{0,0,0,96,48,24,12,6,12,24,48,96,0,0,0,0},
{0,0,0,124,134,7,7,6,12,28,0,28,0,0,0,0},
{0,0,0,62,99,99,111,111,111,110,96,62,0,0,0,0},
{0,0,0,24,60,110,199,135,255,135,135,135,0,0,0,0},
{0,0,0,126,113,113,113,126,113,113,113,126,0,0,0,0},
{0,0,0,62,97,224,224,224,224,224,97,62,0,0,0,0},
{0,0,0,124,114,113,113,113,113,113,114,124,0,0,0,0},
{0,0,0,127,112,112,127,112,112,112,112,127,0,0,0,0},
{0,0,0,127,112,112,127,112,112,112,112,112,0,0,0,0},
{0,0,0,62,99,225,224,224,239,225,97,62,0,0,0,0},
{0,0,0,113,113,113,113,127,113,113,113,113,0,0,0,0},
{0,0,0,56,56,56,56,56,56,56,56,56,0,0,0,0},
{0,0,0,7,7,7,7,7,7,71,71,62,0,0,0,0},
{0,0,0,113,114,114,116,120,116,114,114,113,0,0,0,0},
{0,0,0,112,112,112,112,112,112,112,112,127,0,0,0,0},
{0,0,0,131,199,239,151,135,135,135,135,135,0,0,0,0},
{0,0,0,97,113,121,93,79,71,67,65,65,0,0,0,0},
{0,0,0,60,98,225,225,225,225,225,98,60,0,0,0,0},
{0,0,0,124,114,113,113,114,124,112,112,112,0,0,0,0},
{0,0,0,60,98,225,225,225,225,225,106,60,2,1,0,0},
{0,0,0,124,114,113,113,114,124,114,113,113,0,0,0,0},
{0,0,0,62,97,112,60,30,7,3,67,62,0,0,0,0},
{0,0,0,127,28,28,28,28,28,28,28,28,0,0,0,0},
{0,0,0,113,113,113,113,113,113,113,113,62,0,0,0,0},
{0,0,0,225,225,225,225,225,225,98,36,24,0,0,0,0},
{0,0,0,225,225,225,225,225,233,245,227,193,0,0,0,0},
{0,0,0,129,194,228,120,56,28,46,71,131,0,0,0,0},
{0,0,0,129,193,226,116,56,16,32,64,128,0,0,0,0},
{0,0,0,255,7,14,28,56,112,224,192,255,0,0,0,0},
{0,0,0,60,48,48,48,48,48,48,48,60,0,0,0,0},
{0,0,0,64,96,112,56,28,14,7,3,1,0,0,0,0},
{0,0,0,60,12,12,12,12,12,12,12,60,0,0,0,0},
{0,8,28,54,99,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0,0,0,255,0,0,0},
{0,24,24,12,0,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,124,134,127,231,231,231,123,0,0,0,0},
{0,0,0,224,224,252,230,231,231,231,230,220,0,0,0,0},
{0,0,0,0,0,62,97,224,224,224,97,62,0,0,0,0},
{0,0,0,7,7,63,103,231,231,231,103,59,0,0,0,0},
{0,0,0,0,0,60,102,231,255,224,97,62,0,0,0,0},
{0,0,0,30,57,56,126,56,56,56,56,56,0,0,0,0},
{0,0,0,2,4,126,195,195,195,126,128,254,127,1,0,0},
{0,0,0,224,224,236,247,231,231,231,231,231,0,0,0,0},
{0,0,0,28,0,28,28,28,28,28,28,28,0,0,0,0},
{0,0,0,14,0,14,14,14,14,14,14,78,60,0,0,0},
{0,0,0,224,226,228,232,248,252,238,231,227,0,0,0,0},
{0,0,0,28,28,28,28,28,28,28,28,28,0,0,0,0},
{0,0,0,0,0,114,237,237,237,237,237,237,0,0,0,0},
{0,0,0,0,0,238,247,231,231,231,231,231,0,0,0,0},
{0,0,0,0,0,60,98,225,225,225,98,60,0,0,0,0},
{0,0,0,0,0,220,230,231,231,231,230,252,224,224,0,0},
{0,0,0,0,0,59,103,231,231,231,103,63,7,7,0,0},
{0,0,0,0,0,238,241,224,224,224,224,224,0,0,0,0},
{0,0,0,0,0,62,113,60,30,7,67,62,0,0,0,0},
{0,0,0,56,56,254,56,56,56,56,57,30,0,0,0,0},
{0,0,0,0,0,231,231,231,231,231,231,123,0,0,0,0},
{0,0,0,0,0,225,225,225,225,98,36,24,0,0,0,0},
{0,0,0,0,0,225,225,225,233,245,227,193,0,0,0,0},
{0,0,0,0,0,225,114,60,28,46,71,131,0,0,0,0},
{0,0,0,0,0,225,225,225,225,97,50,28,8,48,192,0},
{0,0,0,0,0,127,7,14,28,56,112,127,0,0,0,0},
{0,0,0,14,24,24,24,112,24,24,24,14,0,0,0,0},
{0,0,0,24,24,24,24,0,24,24,24,24,0,0,0,0},
{0,0,0,112,24,24,24,28,24,24,24,112,0,0,0,0},
{0,0,0,59,110,0,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,8,28,54,99,99,99,127,0,0,0},
{0,0,0,60,102,194,192,192,192,194,102,60,12,6,124,0},
{0,0,0,204,0,0,204,204,204,204,204,204,118,0,0,0},
{0,0,12,24,48,0,124,198,254,192,192,198,124,0,0,0},
{0,0,16,56,108,0,120,12,124,204,204,204,118,0,0,0},
{0,0,0,204,0,0,120,12,124,204,204,204,118,0,0,0},
{0,0,96,48,24,0,120,12,124,204,204,204,118,0,0,0},
{0,0,56,108,56,0,120,12,124,204,204,204,118,0,0,0},
{0,0,0,0,0,60,102,96,96,102,60,12,6,60,0,0},
{0,0,16,56,108,0,124,198,254,192,192,198,124,0,0,0},
{0,0,0,198,0,0,124,198,254,192,192,198,124,0,0,0},
{0,0,96,48,24,0,124,198,254,192,192,198,124,0,0,0},
{0,0,0,102,0,0,56,24,24,24,24,24,60,0,0,0},
{0,0,24,60,102,0,56,24,24,24,24,24,60,0,0,0},
{0,0,96,48,24,0,56,24,24,24,24,24,60,0,0,0},
{0,0,198,0,16,56,108,198,198,254,198,198,198,0,0,0},
{0,56,108,56,0,56,108,198,198,254,198,198,198,0,0,0},
{0,24,48,96,0,254,102,96,124,96,96,102,254,0,0,0},
{0,0,0,0,0,0,204,118,54,126,216,216,110,0,0,0},
{0,0,0,62,108,204,204,254,204,204,204,204,206,0,0,0},
{0,0,16,56,108,0,124,198,198,198,198,198,124,0,0,0},
{0,0,0,198,0,0,124,198,198,198,198,198,124,0,0,0},
{0,0,96,48,24,0,124,198,198,198,198,198,124,0,0,0},
{0,0,48,120,204,0,204,204,204,204,204,204,118,0,0,0},
{0,0,96,48,24,0,204,204,204,204,204,204,118,0,0,0},
{0,0,0,198,0,0,198,198,198,198,198,198,126,6,12,120},
{0,0,198,0,124,198,198,198,198,198,198,198,124,0,0,0},
{0,0,198,0,198,198,198,198,198,198,198,198,124,0,0,0},
{0,0,24,24,60,102,96,96,96,102,60,24,24,0,0,0},
{0,0,56,108,100,96,240,96,96,96,96,230,252,0,0,0},
{0,0,0,102,102,60,24,126,24,126,24,24,24,0,0,0},
{0,0,248,204,204,248,196,204,222,204,204,204,198,0,0,0},
{0,0,14,27,24,24,24,126,24,24,24,24,24,216,112,0},
{0,0,24,48,96,0,120,12,124,204,204,204,118,0,0,0},
{0,0,12,24,48,0,56,24,24,24,24,24,60,0,0,0},
{0,0,24,48,96,0,124,198,198,198,198,198,124,0,0,0},
{0,0,24,48,96,0,204,204,204,204,204,204,118,0,0,0},
{0,0,0,118,220,0,220,102,102,102,102,102,102,0,0,0},
{0,118,220,0,198,230,246,254,222,206,198,198,198,0,0,0},
{0,0,60,108,108,62,0,126,0,0,0,0,0,0,0,0},
{0,0,56,108,108,56,0,124,0,0,0,0,0,0,0,0},
{0,0,0,48,48,0,48,48,96,192,198,198,124,0,0,0},
{0,0,0,0,0,0,0,254,192,192,192,192,0,0,0,0},
{0,0,0,0,0,0,0,254,6,6,6,6,0,0,0,0},
{0,0,192,192,194,198,204,24,48,96,220,134,12,24,62,0},
{0,0,192,192,194,198,204,24,48,102,206,158,62,6,6,0},
{0,0,0,24,24,0,24,24,24,60,60,60,24,0,0,0},
{0,0,0,0,0,0,54,108,216,108,54,0,0,0,0,0},
{0,0,0,0,0,0,216,108,54,108,216,0,0,0,0,0},
{0,17,68,17,68,17,68,17,68,17,68,17,68,17,68,17},
{68,85,170,85,170,85,170,85,170,85,170,85,170,85,170,85},
{170,221,119,221,119,221,119,221,119,221,119,221,119,221,119,221},
{119,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24},
{24,24,24,24,24,24,24,24,248,24,24,24,24,24,24,24},
{24,24,24,24,24,24,248,24,248,24,24,24,24,24,24,24},
{24,54,54,54,54,54,54,54,246,54,54,54,54,54,54,54},
{54,0,0,0,0,0,0,0,254,54,54,54,54,54,54,54},
{54,0,0,0,0,0,248,24,248,24,24,24,24,24,24,24},
{24,54,54,54,54,54,246,6,246,54,54,54,54,54,54,54},
{54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54},
{54,0,0,0,0,0,254,6,246,54,54,54,54,54,54,54},
{54,54,54,54,54,54,246,6,254,0,0,0,0,0,0,0},
{0,54,54,54,54,54,54,54,254,0,0,0,0,0,0,0},
{0,24,24,24,24,24,248,24,248,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,248,24,24,24,24,24,24,24},
{24,24,24,24,24,24,24,24,31,0,0,0,0,0,0,0},
{0,24,24,24,24,24,24,24,255,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,255,24,24,24,24,24,24,24},
{24,24,24,24,24,24,24,24,31,24,24,24,24,24,24,24},
{24,0,0,0,0,0,0,0,255,0,0,0,0,0,0,0},
{0,24,24,24,24,24,24,24,255,24,24,24,24,24,24,24},
{24,24,24,24,24,24,31,24,31,24,24,24,24,24,24,24},
{24,54,54,54,54,54,54,54,55,54,54,54,54,54,54,54},
{54,54,54,54,54,54,55,48,63,0,0,0,0,0,0,0},
{0,0,0,0,0,0,63,48,55,54,54,54,54,54,54,54},
{54,54,54,54,54,54,247,0,255,0,0,0,0,0,0,0},
{0,0,0,0,0,0,255,0,247,54,54,54,54,54,54,54},
{54,54,54,54,54,54,55,48,55,54,54,54,54,54,54,54},
{54,0,0,0,0,0,255,0,255,0,0,0,0,0,0,0},
{0,54,54,54,54,54,247,0,247,54,54,54,54,54,54,54},
{54,24,24,24,24,24,255,0,255,0,0,0,0,0,0,0},
{0,54,54,54,54,54,54,54,255,0,0,0,0,0,0,0},
{0,0,0,0,0,0,255,0,255,24,24,24,24,24,24,24},
{24,0,0,0,0,0,0,0,255,54,54,54,54,54,54,54},
{54,54,54,54,54,54,54,54,63,0,0,0,0,0,0,0},
{0,24,24,24,24,24,31,24,31,0,0,0,0,0,0,0},
{0,0,0,0,0,0,31,24,31,24,24,24,24,24,24,24},
{24,0,0,0,0,0,0,0,63,54,54,54,54,54,54,54},
{54,54,54,54,54,54,54,54,255,54,54,54,54,54,54,54},
{54,24,24,24,24,24,255,24,255,24,24,24,24,24,24,24},
{24,24,24,24,24,24,24,24,248,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,31,24,24,24,24,24,24,24},
{24,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255},
{255,0,0,0,0,0,0,0,255,255,255,255,255,255,255,255},
{255,240,240,240,240,240,240,240,240,240,240,240,240,240,240,240},
{240,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15},
{15,255,255,255,255,255,255,255,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,118,220,216,216,216,220,118,0,0,0},
{0,0,0,120,204,204,204,216,204,198,198,198,204,0,0,0},
{0,0,0,254,198,198,192,192,192,192,192,192,192,0,0,0},
{0,0,0,0,0,254,108,108,108,108,108,108,108,0,0,0},
{0,0,0,0,254,198,96,48,24,48,96,198,254,0,0,0},
{0,0,0,0,0,0,126,216,216,216,216,216,112,0,0,0},
{0,0,0,0,0,102,102,102,102,102,124,96,96,192,0,0},
{0,0,0,0,0,118,220,24,24,24,24,24,24,0,0,0},
{0,0,0,0,126,24,60,102,102,102,60,24,126,0,0,0},
{0,0,0,0,56,108,198,198,254,198,198,108,56,0,0,0},
{0,0,0,56,108,198,198,198,108,108,108,108,238,0,0,0},
{0,0,0,30,48,24,12,62,102,102,102,102,60,0,0,0},
{0,0,0,0,0,0,126,219,219,219,126,0,0,0,0,0},
{0,0,0,0,3,6,126,219,219,243,126,96,192,0,0,0},
{0,0,0,28,48,96,96,124,96,96,96,48,28,0,0,0},
{0,0,0,0,124,198,198,198,198,198,198,198,198,0,0,0},
{0,0,0,0,0,254,0,0,254,0,0,254,0,0,0,0},
{0,0,0,0,0,24,24,126,24,24,0,0,255,0,0,0},
{0,0,0,0,48,24,12,6,12,24,48,0,126,0,0,0},
{0,0,0,0,12,24,48,96,48,24,12,0,126,0,0,0},
{0,0,0,14,27,27,24,24,24,24,24,24,24,24,24,24},
{24,24,24,24,24,24,24,24,24,216,216,216,112,0,0,0},
{0,0,0,0,0,24,24,0,126,0,24,24,0,0,0,0},
{0,0,0,0,0,0,118,220,0,118,220,0,0,0,0,0},
{0,0,56,108,108,56,0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,24,24,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,24,0,0,0,0,0,0},
{0,0,15,12,12,12,12,12,236,108,108,60,28,0,0,0},
{0,0,216,108,108,108,108,108,0,0,0,0,0,0,0,0},
{0,0,112,216,48,96,200,248,0,0,0,0,0,0,0,0},
{0,0,0,0,0,124,124,124,124,124,124,124,0,0,0,0},
{92,79,114,97,99,108,101,92,34,183,222,70,241,189,0,0}};
        public static void DrawBitFontString(Texture2D target, byte[,] bitfont, int x, int y, string str, Color c)
        {
            int h = 16;
            int w = 8;
            foreach (var ch in str)
            {
                int charidx = ch;
                for (int cy = 0; cy < h; ++cy)
                {
                    byte row = bitfont[charidx, cy];
                    int ccy = y + h - cy;
                    for (int cx = 0; cx < w; ++cx)
                    {
                        if ((row & (1 << cx)) != 0)
                            target.SetPixel(x + w - cx, ccy, c);
                    }
                }
                x += w;
            }
        }

        public static void FillRect(Texture2D target, int x, int y, int w, int h, Color c)
        {
            for (int cy = y; cy < y + h; ++cy)
                for (int cx = x; cx < x + w; ++cx)
                    target.SetPixel(cx, cy, c);
        }

    }
}