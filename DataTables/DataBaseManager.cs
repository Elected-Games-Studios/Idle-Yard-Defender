﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class DataBaseTurrets
{
    private static Int64[,] defaultstart = new Int64[50, 4]//should be written too for each yard on save and passed to the saver. 
    {{ 1, 0, 0, 0 },{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
    private static List<Int64[,]> yards;//lists of all arrays of int[,]
    private static Int64[,] turrets = new Int64[1000, 3] // [level,(rof,str,ctu)]
        {{1,5,100},{ 1, 5, 103 },{ 1, 5, 106 },{ 1, 5, 109 },{ 1, 5, 113 },{ 1, 5, 116 },{ 1, 5, 120 },{ 1, 5, 124 },{ 1, 5, 128 },{ 1, 5, 132 },{ 1, 5, 136 },{ 1, 6, 140 },{ 1, 6, 144 },{ 1, 6, 149 },{ 1, 6, 154 },{ 1, 6, 158 },{ 1, 6, 163 },{ 1, 6, 169 },{ 1, 6, 174 },{ 1, 6, 179 },{ 1, 7, 185 },{ 1, 7, 191 },{ 1, 7, 197 },{ 1, 7, 203 },{ 1, 7, 209 },{ 1, 7, 216 },{ 1, 7, 223 },{ 1, 7, 230 },{ 1, 8, 237 },{ 1, 8, 244 },{ 1, 8, 252 },{ 1, 8, 260 },{ 1, 8, 268 },{ 1, 8, 277 },{ 1, 8, 285 },{ 1, 9, 294 },{ 1, 9, 303 },{ 1, 9, 313 },{ 1, 9, 323 },{ 1, 9, 333 },{ 1, 9, 343 },{ 1, 10, 354 },{ 1, 10, 365 },{ 1, 10, 377 },{ 1, 10, 389 },{ 1, 10, 401 },{ 1, 11, 413 },{ 1, 11, 426 },{ 1, 11, 440 },{ 1, 11, 454 },{ 1, 11, 468 },{ 1, 12, 483 },{ 1, 12, 498 },{ 1, 12, 513 },{ 1, 12, 529 },{ 1, 12, 546 },{ 1, 13, 563 },{ 1, 13, 581 },{ 1, 13, 599 },{ 1, 13, 618 },{ 1, 14, 637 },{ 1, 14, 657 },{ 1, 14, 678 },{ 1, 14, 699 },{ 1, 15, 721 },{ 1, 15, 744 },{ 1, 15, 767 },{ 1, 15, 791 },{ 1, 16, 816 },{ 1, 16, 842 },{ 1, 16, 868 },{ 1, 16, 895 },{ 1, 17, 923 },{ 1, 17, 952 },{ 1, 17, 982 },{ 1, 18, 1013 },{ 1, 18, 1045 },{ 1, 18, 1078 },{ 1, 19, 1112 },{ 1, 19, 1146 },{ 1, 19, 1182 },{ 1, 20, 1220 },{ 1, 20, 1258 },{ 1, 20, 1297 },{ 1, 21, 1338 },{ 1, 21, 1380 },{ 1, 22, 1423 },{ 1, 22, 1468 },{ 1, 22, 1514 },{ 1, 23, 1561 },{ 1, 23, 1610 },{ 1, 23, 1661 },{ 1, 24, 1713 },{ 1, 24, 1767 },{ 1, 25, 1822 },{ 1, 25, 1879 },{ 1, 26, 1938 },{ 1, 26, 1999 },{ 1, 27, 2062 },{ 1, 27, 2127 },{ 1, 28, 2193 },{ 1, 28, 2262 },{ 1, 29, 2333 },{ 1, 29, 2406 },{ 1, 30, 2482 },{ 1, 30, 2560 },{ 1, 31, 2640 },{ 1, 31, 2723 },{ 1, 32, 2808 },{ 1, 32, 2896 },{ 1, 33, 2987 },{ 1, 33, 3081 },{ 1, 34, 3177 },{ 1, 35, 3277 },{ 1, 35, 3380 },{ 1, 36, 3486 },{ 1, 36, 3595 },{ 1, 37, 3708 },{ 1, 38, 3824 },{ 1, 38, 3944 },{ 1, 39, 4068 },{ 1, 40, 4196 },{ 1, 40, 4327 },{ 1, 41, 4463 },{ 1, 42, 4603 },{ 1, 43, 4747 },{ 1, 43, 4896 },{ 1, 44, 5050 },{ 1, 45, 5208 },{ 1, 46, 5372 },{ 1, 46, 5540 },{ 1, 47, 5714 },{ 1, 48, 5893 },{ 1, 49, 6078 },{ 1, 50, 6269 },{ 1, 51, 6465 },{ 1, 52, 6668 },{ 1, 53, 6877 },{ 1, 53, 7093 },{ 1, 54, 7315 },{ 1, 55, 7545 },{ 1, 56, 7781 },{ 1, 57, 8026 },{ 1, 58, 8277 },{ 1, 59, 8537 },{ 1, 60, 8805 },{ 1, 61, 9081 },{ 1, 62, 9366 },{ 1, 64, 9659 },{ 1, 65, 9962 },{ 1, 66, 10275 },{ 1, 67, 10597 },{ 1, 68, 10929 },{ 1, 69, 11272 },{ 1, 71, 11626 },{ 1, 72, 11990 },{ 1, 73, 12367 },{ 1, 74, 12754 },{ 1, 76, 13155 },{ 1, 77, 13567 },{ 1, 78, 13993 },{ 1, 80, 14432 },{ 1, 81, 14884 },{ 1, 83, 15351 },{ 1, 84, 15832 },{ 1, 85, 16329 },{ 1, 87, 16841 },{ 1, 88, 17369 },{ 1, 90, 17914 },{ 1, 92, 18476 },{ 1, 93, 19056 },{ 1, 95, 19653 },{ 1, 96, 20270 },{ 1, 98, 20905 },{ 1, 100, 21561 },{ 1, 102, 22237 },{ 1, 103, 22935 },{ 1, 105, 23654 },{ 1, 107, 24396 },{ 1, 109, 25161 },{ 1, 111, 25951 },{ 1, 113, 26764 },{ 1, 115, 27604 },{ 1, 117, 28470 },{ 1, 119, 29363 },{ 1, 121, 30284 },{ 1, 123, 31233 },{ 1, 125, 32213 },{ 1, 127, 33223 },{ 1, 129, 34265 },{ 1, 132, 35340 },{ 1, 134, 36449 },{ 1, 136, 37592 },{ 1, 139, 38771 },{ 1, 141, 39987 },{ 1, 144, 41241 },{ 1, 146, 42534 },{ 1, 149, 43868 },{ 1, 151, 45244 },{ 1, 154, 46663 },{ 2, 157, 48127 },{ 2, 159, 49637 },{ 2, 162, 51193 },{ 2, 165, 52799 },{ 2, 168, 54455 },{ 2, 171, 56163 },{ 2, 174, 57924 },{ 2, 177, 59741 },{ 2, 180, 61615 },{ 2, 183, 63547 },{ 2, 186, 65541 },{ 2, 189, 67596 },{ 2, 193, 69716 },{ 2, 196, 71903 },{ 2, 199, 74158 },{ 2, 203, 76484 },{ 2, 206, 78883 },{ 2, 210, 81357 },{ 2, 214, 83909 },{ 2, 217, 86540 },{ 2, 221, 89255 },{ 2, 225, 92054 },{ 2, 229, 94941 },{ 2, 233, 97919 },{ 2, 237, 100990 },{ 2, 241, 104158 },{ 2, 245, 107424 },{ 2, 250, 110794 },{ 2, 254, 114269 },{ 2, 258, 117853 },{ 2, 263, 121549 },{ 2, 267, 125361 },{ 2, 272, 129293 },{ 2, 277, 133348 },{ 2, 282, 137530 },{ 2, 287, 141844 },{ 2, 292, 146293 },{ 2, 297, 150881 },{ 2, 302, 155613 },{ 2, 307, 160494 },{ 2, 312, 165528 },{ 2, 318, 170719 },{ 2, 323, 176074 },{ 2, 329, 181596 },{ 2, 335, 187292 },{ 2, 341, 193166 },{ 2, 347, 199225 },{ 2, 353, 205473 },{ 2, 359, 211918 },{ 2, 365, 218564 },{ 2, 371, 225419 },{ 2, 378, 232489 },{ 2, 384, 239781 },{ 2, 391, 247302 },{ 2, 398, 255058 },{ 2, 405, 263058 },{ 2, 412, 271308 },{ 2, 419, 279818 },{ 2, 426, 288594 },{ 2, 434, 297645 },{ 2, 441, 306981 },{ 2, 449, 316609 },{ 2, 457, 326539 },{ 2, 465, 336781 },{ 2, 473, 347343 },{ 2, 481, 358237 },{ 2, 489, 369473 },{ 2, 498, 381061 },{ 2, 507, 393013 },{ 2, 515, 405339 },{ 2, 524, 418053 },{ 2, 533, 431164 },{ 2, 543, 444687 },{ 2, 552, 458635 },{ 2, 562, 473019 },{ 2, 572, 487855 },{ 2, 581, 503156 },{ 2, 592, 518937 },{ 2, 602, 535213 },{ 2, 612, 552000 },{ 2, 623, 569312 },{ 2, 634, 587168 },{ 2, 645, 605584 },{ 2, 656, 624578 },{ 2, 668, 644167 },{ 2, 679, 664371 },{ 2, 691, 685208 },{ 2, 703, 706699 },{ 2, 715, 728864 },{ 2, 728, 751724 },{ 2, 740, 775301 },{ 2, 753, 799618 },{ 2, 766, 824697 },{ 2, 780, 850563 },{ 2, 793, 877240 },{ 2, 807, 904754 },{ 2, 821, 933130 },{ 2, 835, 962397 },{ 2, 850, 992582 },{ 2, 865, 1023713 },{ 2, 880, 1055821 },{ 2, 895, 1088936 },{ 2, 911, 1123089 },{ 2, 926, 1158314 },{ 2, 942, 1194643 },{ 2, 959, 1232112 },{ 2, 976, 1270756 },{ 2, 993, 1310612 },{ 2, 1010, 1351718 },{ 2, 1027, 1394113 },{ 2, 1045, 1437838 },{ 2, 1063, 1482934 },{ 2, 1082, 1529445 },{ 2, 1101, 1577415 },{ 2, 1120, 1626889 },{ 2, 1139, 1677915 },{ 2, 1159, 1730541 },{ 2, 1179, 1784817 },{ 2, 1200, 1840796 },{ 2, 1221, 1898531 },{ 2, 1242, 1958077 },{ 2, 1264, 2019490 },{ 2, 1286, 2082829 },{ 2, 1308, 2148155 },{ 2, 1331, 2215530 },{ 2, 1354, 2285018 },{ 2, 1377, 2356685 },{ 2, 1401, 2430600 },{ 2, 1426, 2506833 },{ 2, 1450, 2585458 },{ 2, 1476, 2666548 },{ 2, 1501, 2750182 },{ 2, 1527, 2836438 },{ 2, 1554, 2925401 },{ 2, 1581, 3017153 },{ 2, 1608, 3111783 },{ 2, 1636, 3209381 },{ 2, 1665, 3310040 },{ 2, 1694, 3413856 },{ 2, 1723, 3520928 },{ 2, 1753, 3631358 },{ 2, 1784, 3745252 },{ 2, 1815, 3862719 },{ 2, 1846, 3983869 },{ 2, 1878, 4108819 },{ 2, 1911, 4237688 },{ 2, 1944, 4370599 },{ 2, 1978, 4507678 },{ 2, 2013, 4649057 },{ 2, 2048, 4794870 },{ 2, 2083, 4945256 },{ 2, 2119, 5100360 },{ 2, 2156, 5260327 },{ 2, 2194, 5425312 },{ 2, 2232, 5595472 },{ 2, 2271, 5770968 },{ 2, 2310, 5951969 },{ 2, 2350, 6138646 },{ 2, 2391, 6331179 },{ 2, 2433, 6529750 },{ 2, 2475, 6734549 },{ 2, 2518, 6945771 },{ 2, 2562, 7163619 },{ 2, 2607, 7388298 },{ 2, 2652, 7620025 },{ 2, 2698, 7859019 },{ 2, 2745, 8105510 },{ 2, 2793, 8359731 },{ 2, 2841, 8621926 },{ 2, 2891, 8892344 },{ 2, 2941, 9171243 },{ 2, 2992, 9458890 },{ 2, 3044, 9755559 },{ 2, 3097, 10061532 },{ 2, 3151, 10377102 },{ 2, 3206, 10702569 },{ 2, 3261, 11038245 },{ 2, 3318, 11384448 },{ 2, 3376, 11741510 },{ 2, 3434, 12109771 },{ 2, 3494, 12489582 },{ 2, 3555, 12881305 },{ 2, 3617, 13285314 },{ 2, 3680, 13701995 },{ 2, 3744, 14131744 },{ 2, 3809, 14574972 },{ 2, 3875, 15032102 },{ 2, 3942, 15503569 },{ 2, 4011, 15989822 },{ 2, 4080, 16491327 },{ 2, 4151, 17008561 },{ 2, 4224, 17542018 },{ 2, 4297, 18092206 },{ 2, 4372, 18659650 },{ 2, 4448, 19244891 },{ 2, 4525, 19848488 },{ 2, 4604, 20471016 },{ 2, 4684, 21113069 },{ 2, 4765, 21775259 },{ 2, 4848, 22458218 },{ 3, 4932, 23162598 },{ 3, 5018, 23889069 },{ 3, 5105, 24638326 },{ 3, 5194, 25411083 },{ 3, 5284, 26208076 },{ 3, 5376, 27030066 },{ 3, 5470, 27877837 },{ 3, 5565, 28752198 },{ 3, 5662, 29653982 },{ 3, 5760, 30584049 },{ 3, 5860, 31543287 },{ 3, 5962, 32532611 },{ 3, 6066, 33552964 },{ 3, 6171, 34605319 },{ 3, 6279, 35690680 },{ 3, 6388, 36810083 },{ 3, 6499, 37964594 },{ 3, 6612, 39155316 },{ 3, 6727, 40383383 },{ 3, 6844, 41649967 },{ 3, 6963, 42956277 },{ 3, 7084, 44303558 },{ 3, 7207, 45693094 },{ 3, 7332, 47126213 },{ 3, 7460, 48604279 },{ 3, 7589, 50128704 },{ 3, 7721, 51700940 },{ 3, 7856, 53322489 },{ 3, 7992, 54994895 },{ 3, 8131, 56719755 },{ 3, 8272, 58498714 },{ 3, 8416, 60333467 },{ 3, 8563, 62225766 },{ 3, 8712, 64177415 },{ 3, 8863, 66190276 },{ 3, 9017, 68266267 },{ 3, 9174, 70407371 },{ 3, 9333, 72615627 },{ 3, 9496, 74893144 },{ 3, 9661, 77242093 },{ 3, 9829, 79664714 },{ 3, 10000, 82163318 },{ 3, 10173, 84740288 },{ 3, 10350, 87398082 },{ 3, 10530, 90139236 },{ 3, 10713, 92966363 },{ 3, 10900, 95882160 },{ 3, 11089, 98889408 },{ 3, 11282, 101990975 },{ 3, 11478, 105189820 },{ 3, 11678, 108488994 },{ 3, 11881, 111891643 },{ 3, 12087, 115401012 },{ 3, 12297, 119020450 },{ 3, 12511, 122753407 },{ 3, 12729, 126603445 },{ 3, 12950, 130574235 },{ 3, 13175, 134669566 },{ 3, 13404, 138893342 },{ 3, 13637, 143249593 },{ 3, 13874, 147742473 },{ 3, 14115, 152376268 },{ 3, 14361, 157155397 },{ 3, 14610, 162084419 },{ 3, 14864, 167168035 },{ 3, 15123, 172411093 },{ 3, 15386, 177818595 },{ 3, 15653, 183395697 },{ 3, 15925, 189147720 },{ 3, 16202, 195080149 },{ 3, 16484, 201198642 },{ 3, 16771, 207509037 },{ 3, 17062, 214017350 },{ 3, 17359, 220729790 },{ 3, 17661, 227652759 },{ 3, 17968, 234792861 },{ 3, 18280, 242156904 },{ 3, 18598, 249751913 },{ 3, 18921, 257585132 },{ 3, 19250, 265664032 },{ 3, 19585, 273996319 },{ 3, 19925, 282589940 },{ 3, 20272, 291453090 },{ 3, 20624, 300594225 },{ 3, 20983, 310022062 },{ 3, 21347, 319745594 },{ 3, 21719, 329774095 },{ 3, 22096, 340117130 },{ 3, 22480, 350784564 },{ 3, 22871, 361786571 },{ 3, 23269, 373133645 },{ 3, 23673, 384836608 },{ 3, 24085, 396906624 },{ 3, 24504, 409355203 },{ 3, 24930, 422194220 },{ 3, 25363, 435435919 },{ 3, 25804, 449092931 },{ 3, 26253, 463178282 },{ 3, 26709, 477705406 },{ 3, 27173, 492688158 },{ 3, 27646, 508140830 },{ 3, 28126, 524078159 },{ 3, 28615, 540515346 },{ 3, 29113, 557468069 },{ 3, 29619, 574952498 },{ 3, 30134, 592985308 },{ 3, 30658, 611583699 },{ 3, 31191, 630765410 },{ 3, 31733, 650548737 },{ 3, 32285, 670952547 },{ 3, 32846, 691996303 },{ 3, 33417, 713700075 },{ 3, 33998, 736084564 },{ 3, 34589, 759171121 },{ 3, 35190, 782981764 },{ 3, 35802, 807539204 },{ 3, 36425, 832866863 },{ 3, 37058, 858988900 },{ 3, 37702, 885930227 },{ 3, 38358, 913716543 },{ 3, 39024, 942374349 },{ 3, 39703, 971930978 },{ 3, 40393, 1002414621 },{ 3, 41095, 1033854353 },{ 3, 41810, 1066280161 },{ 3, 42537, 1099722972 },{ 3, 43276, 1134214684 },{ 3, 44029, 1169788193 },{ 3, 44794, 1206477430 },{ 3, 45573, 1244317388 },{ 3, 46365, 1283344159 },{ 3, 47171, 1323594965 },{ 3, 47991, 1365108197 },{ 3, 48825, 1407923451 },{ 3, 49674, 1452081562 },{ 3, 50538, 1497624648 },{ 3, 51417, 1544596147 },{ 3, 52310, 1593040861 },{ 3, 53220, 1643004995 },{ 3, 54145, 1694536203 },{ 3, 55086, 1747683637 },{ 3, 56044, 1802497986 },{ 3, 57018, 1859031533 },{ 3, 58010, 1917338198 },{ 3, 59018, 1977473594 },{ 3, 60044, 2039495075 },{ 3, 61088, 2103461799 },{ 3, 62150, 2169434775 },{ 3, 63231, 2237476927 },{ 3, 64330, 2307653153 },{ 3, 65448, 2380030387 },{ 3, 66586, 2454677660 },{ 3, 67744, 2531666170 },{ 3, 68921, 2611069348 },{ 3, 70120, 2692962927 },{ 3, 71339, 2777425016 },{ 3, 72579, 2864536174 },{ 3, 73841, 2954379487 },{ 3, 75124, 3047040645 },{ 3, 76431, 3142608028 },{ 3, 77759, 3241172786 },{ 3, 79111, 3342828930 },{ 3, 80486, 3447673416 },{ 3, 81886, 3555806245 },{ 3, 83309, 3667330552 },{ 3, 84758, 3782352708 },{ 3, 86231, 3900982418 },{ 3, 87730, 4023332831 },{ 3, 89256, 4149520642 },{ 3, 90807, 4279666207 },{ 3, 92386, 4413893658 },{ 3, 93992, 4552331019 },{ 3, 95626, 4695110329 },{ 3, 97289, 4842367769 },{ 3, 98980, 4994243792 },{ 3, 100701, 5150883254 },{ 3, 102451, 5312435556 },{ 3, 104233, 5479054785 },{ 3, 106045, 5650899860 },{ 3, 107888, 5828134683 },{ 3, 109764, 6010928299 },{ 3, 111672, 6199455054 },{ 3, 113614, 6393894763 },{ 3, 115589, 6594432878 },{ 3, 117598, 6801260671 },{ 3, 119643, 7014575410 },{ 3, 121723, 7234580554 },{ 3, 123839, 7461485938 },{ 3, 125992, 7695507983 },{ 3, 128182, 7936869895 },{ 3, 130411, 8185801883 },{ 3, 132678, 8442541373 },{ 3, 134984, 8707333241 },{ 3, 137331, 8980430041 },{ 3, 139719, 9262092248 },{ 3, 142148, 9552588510 },{ 3, 144619, 9852195896 },{ 3, 147133, 10161200168 },{ 3, 149691, 10479896050 },{ 3, 152294, 10808587510 },{ 4, 154941, 11147588048 },{ 4, 157635, 11497221000 },{ 4, 160375, 11857819839 },{ 4, 163163, 12229728501 },{ 4, 166000, 12613301705 },{ 4, 168886, 13008905300 },{ 4, 171822, 13416916606 },{ 4, 174809, 13837724778 },{ 4, 177848, 14271731178 },{ 4, 180940, 14719349755 },{ 4, 184086, 15181007441 },{ 4, 187286, 15657144558 },{ 4, 190542, 16148215240 },{ 4, 193855, 16654687863 },{ 4, 197225, 17177045493 },{ 4, 200654, 17715786348 },{ 4, 204142, 18271424271 },{ 4, 207691, 18844489222 },{ 4, 211302, 19435527782 },{ 4, 214975, 20045103675 },{ 4, 218713, 20673798307 },{ 4, 222515, 21322211317 },{ 4, 226383, 21990961153 },{ 4, 230319, 22680685658 },{ 4, 234323, 23392042683 },{ 4, 238397, 24125710710 },{ 4, 242541, 24882389501 },{ 4, 246758, 25662800765 },{ 4, 251048, 26467688848 },{ 4, 255412, 27297821441 },{ 4, 259853, 28153990313 },{ 4, 264370, 29037012065 },{ 4, 268966, 29947728912 },{ 4, 273642, 30887009481 },{ 4, 278400, 31855749647 },{ 4, 283240, 32854873378 },{ 4, 288164, 33885333627 },{ 4, 293173, 34948113231 },{ 4, 298270, 36044225854 },{ 4, 303456, 37174716954 },{ 4, 308731, 38340664777 },{ 4, 314099, 39543181387 },{ 4, 319559, 40783413728 },{ 4, 325115, 42062544716 },{ 4, 330767, 43381794368 },{ 4, 336517, 44742420967 },{ 4, 342368, 46145722258 },{ 4, 348320, 47593036691 },{ 4, 354375, 49085744694 },{ 4, 360536, 50625269991 },{ 4, 366804, 52213080959 },{ 4, 373181, 53850692030 },{ 4, 379669, 55539665135 },{ 4, 386269, 57281611192 },{ 4, 392985, 59078191645 },{ 4, 399817, 60931120048 },{ 4, 406767, 62842163697 },{ 4, 413839, 64813145320 },{ 4, 421034, 66845944809 },{ 4, 428353, 68942501022 },{ 4, 435800, 71104813625 },{ 4, 443377, 73334944999 },{ 4, 451085, 75635022214 },{ 4, 458927, 78007239051 },{ 4, 466905, 80453858096 },{ 4, 475022, 82977212902 },{ 4, 483281, 85579710207 },{ 4, 491683, 88263832238 },{ 4, 500231, 91032139072 },{ 4, 508927, 93887271082 },{ 4, 517775, 96831951453 },{ 4, 526776, 99868988778 },{ 4, 535934, 103001279742 },{ 4, 545251, 106231811880 },{ 4, 554731, 109563666428 },{ 4, 564375, 113000021262 },{ 4, 574186, 116544153928 },{ 4, 584169, 120199444772 },{ 4, 594324, 123969380158 },{ 4, 604657, 127857555797 },{ 4, 615169, 131867680177 },{ 4, 625863, 136003578099 },{ 4, 636744, 140269194322 },{ 4, 647814, 144668597333 },{ 4, 659076, 149205983220 },{ 4, 670534, 153885679677 },{ 4, 682191, 158712150135 },{ 4, 694051, 163689998011 },{ 4, 706117, 168823971109 },{ 4, 718393, 174118966139 },{ 4, 730883, 179580033393 },{ 4, 743589, 185212381560 },{ 4, 756516, 191021382696 },{ 4, 769668, 197012577343 },{ 4, 783049, 203191679818 },{ 4, 796662, 209564583664 },{ 4, 810512, 216137367266 },{ 4, 824603, 222916299653 },{ 4, 838939, 229907846476 },{ 4, 853524, 237118676172 },{ 4, 868362, 244555666332 },{ 4, 883459, 252225910251 },{ 4, 898818, 260136723700 },{ 4, 914444, 268295651902 },{ 4, 930341, 276710476728 },{ 4, 946515, 285389224120 },{ 4, 962970, 294340171746 },{ 4, 979712, 303571856892 },{ 4, 996744, 313093084612 },{ 4, 1014072, 322912936118 },{ 4, 1031702, 333040777446 },{ 4, 1049638, 343486268390 },{ 4, 1067886, 354259371712 },{ 4, 1086451, 365370362646 },{ 4, 1105339, 376829838700 },{ 4, 1124556, 388648729761 },{ 4, 1144106, 400838308521 },{ 4, 1163996, 413410201230 },{ 4, 1184232, 426376398781 },{ 4, 1204820, 439749268153 },{ 4, 1225766, 453541564199 },{ 4, 1247076, 467766441819 },{ 4, 1268756, 482437468500 },{ 4, 1290814, 497568637262 },{ 4, 1313255, 513174380001 },{ 4, 1336086, 529269581255 },{ 4, 1359313, 545869592402 },{ 4, 1382945, 562990246298 },{ 4, 1406988, 580647872383 },{ 4, 1431448, 598859312252 },{ 4, 1456334, 617641935722 },{ 4, 1481652, 637013657394 },{ 4, 1507411, 656992953744 },{ 4, 1533617, 677598880746 },{ 4, 1560279, 698851092041 },{ 4, 1587404, 720769857692 },{ 4, 1615001, 743376083509 },{ 4, 1643078, 766691330992 },{ 4, 1671643, 790737837897 },{ 4, 1700705, 815538539445 },{ 4, 1730272, 841117090196 },{ 4, 1760352, 867497886613 },{ 4, 1790956, 894706090329 },{ 4, 1822092, 922767652146 },{ 4, 1853769, 951709336788 },{ 4, 1885997, 981558748427 },{ 4, 1918785, 1012344357013 },{ 4, 1952143, 1044095525426 },{ 4, 1986081, 1076842537485 },{ 4, 2020609, 1110616626831 },{ 4, 2055737, 1145450006715 },{ 4, 2091476, 1181375900726 },{ 4, 2127836, 1218428574476 },{ 4, 2164829, 1256643368286 },{ 4, 2202464, 1296056730889 },{ 4, 2240754, 1336706254196 },{ 4, 2279710, 1378630709153 },{ 4, 2319343, 1421870082715 },{ 4, 2359664, 1466465615989 },{ 4, 2400687, 1512459843569 },{ 4, 2442423, 1559896634103 },{ 4, 2484885, 1608821232135 },{ 4, 2528084, 1659280301260 },{ 4, 2572035, 1711321968628 },{ 4, 2616750, 1764995870852 },{ 4, 2662242, 1820353201346 },{ 4, 2708525, 1877446759153 },{ 4, 2755613, 1936330999307 },{ 4, 2803519, 1997062084769 },{ 4, 2852259, 2059697939996 },{ 4, 2901845, 2124298306186 },{ 4, 2952294, 2190924798261 },{ 4, 3003619, 2259640963634 },{ 4, 3055837, 2330512342817 },{ 4, 3108963, 2403606531937 },{ 4, 3163012, 2478993247205 },{ 4, 3218001, 2556744391410 },{ 4, 3273946, 2636934122503 },{ 4, 3330864, 2719638924321 },{ 4, 3388771, 2804937679543 },{ 4, 3447685, 2892911744925 },{ 4, 3507623, 2983645028892 },{ 4, 3568603, 3077224071579 },{ 4, 3630643, 3173738127360 },{ 4, 3693762, 3273279249986 },{ 4, 3757978, 3375942380383 },{ 4, 3823310, 3481825437201 },{ 4, 3889778, 3591029410213 },{ 4, 3957402, 3703658456635 },{ 4, 4026202, 3819820000469 },{ 4, 4096197, 3939624834964 },{ 4, 4167409, 4063187228288 },{ 4, 4239860, 4190625032516 },{ 4, 4313570, 4322059796036 },{ 4, 4388561, 4457616879479 },{ 4, 4464856, 4597425575287 },{ 4, 4542478, 4741619231030 },{ 4, 4621449, 4890335376592 },{ 4, 4701793, 5043715855343 },{ 4, 4783534, 5201906959430 },{ 5, 4866695, 5365059569306 },{ 5, 4951303, 5533329297638 },{ 5, 5037381, 5706876637729 },{ 5, 5124956, 5885867116595 },{ 5, 5214053, 6070471452839 },{ 5, 5304700, 6260865719486 },{ 5, 5396922, 6457231511912 },{ 5, 5490747, 6659756121052 },{ 5, 5586204, 6868632712033 },{ 5, 5683320, 7084060508413 },{ 5, 5782125, 7306244982199 },{ 5, 5882647, 7535398049820 },{ 5, 5984917, 7771738274255 },{ 5, 6088965, 8015491073489 },{ 5, 6194821, 8266888935518 },{ 5, 6302518, 8526171640091 },{ 5, 6412088, 8793586487411 },{ 5, 6523562, 9069388534002 },{ 5, 6636974, 9353840835983 },{ 5, 6752358, 9647214699962 },{ 5, 6869747, 9949789941812 },{ 5, 6989178, 10261855153547 },{ 5, 7110685, 10583707978583 },{ 5, 7234304, 10915655395623 },{ 5, 7360073, 11258014011452 },{ 5, 7488027, 11611110362907 },{ 5, 7618207, 11975281228329 },{ 5, 7750649, 12350873948774 },{ 5, 7885394, 12738246759304 },{ 5, 8022482, 13137769130662 },{ 5, 8161953, 13549822121677 },{ 5, 8303848, 13974798742701 },{ 5, 8448211, 14413104330467 },{ 5, 8595083, 14865156934688 },{ 5, 8744508, 15331387716787 },{ 5, 8896532, 15812241361137 },{ 5, 9051198, 16308176499187 },{ 5, 9208553, 16819666146908 },{ 5, 9368644, 17347198155939 },{ 5, 9531518, 17891275678902 },{ 5, 9697223, 18452417649295 },{ 5, 9865809, 19031159276448 },{ 5, 10037326, 19628052555995 },{ 5, 10211825, 20243666796361 },{ 5, 10389358, 20878589161762 },{ 5, 10569977, 21533425232231 },{ 5, 10753736, 22208799581215 },{ 5, 10940690, 22905356371280 },{ 5, 11130894, 23623759968509 },{ 5, 11324404, 24364695576162 },{ 5, 11521279, 25128869888212 },{ 5, 11721576, 25917011763386 },{ 5, 11925356, 26729872920333 },{ 5, 12132678, 27568228654606 },{ 5, 12343605, 28432878578129 },{ 5, 12558199, 29324647381854 },{ 5, 12776523, 30244385622338 },{ 5, 12998643, 31192970532997 },{ 5, 13224624, 32171306860794 },{ 5, 13454534, 33180327729176 },{ 5, 13688441, 34220995528074 },{ 5, 13926415, 35294302831817 },{ 5, 14168526, 36401273345834 },{ 5, 14414845, 37542962883053 },{ 5, 14665448, 38720460370917 },{ 5, 14920406, 39934888889990 },{ 5, 15179798, 41187406745136 },{ 5, 15443698, 42479208570290 },{ 5, 15712187, 43811526467889 },{ 5, 15985343, 45185631184028 },{ 5, 16263249, 46602833320484 },{ 5, 16545985, 48064484584747 },{ 5, 16833637, 49571979079263 },{ 5, 17126290, 51126754631105 },{ 5, 17424031, 52730294163355 },{ 5, 17726947, 54384127109495 },{ 5, 18035130, 56089830872157 },{ 5, 18348671, 57849032327631 },{ 5, 18667663, 59663409377555 },{ 5, 18992200, 61534692549273 },{ 5, 19322379, 63464666646388 },{ 5, 19658299, 65455172451086 },{ 5, 20000059, 67508108479841 },{ 5, 20347760, 69625432794203 },{ 5, 20701505, 71809164868361 },{ 5, 21061401, 74061387515292 },{ 5, 21427554, 76384248873322 },{ 5, 21800072, 78779964454984 },{ 5, 22179066, 81250819260151 },{ 5, 22564649, 83799169955426 },{ 5, 22956935, 86427447121908 },{ 5, 23356042, 89138157573439 },{ 5, 23762086, 91933886747573 },{ 5, 24175190, 94817301171524 },{ 5, 24595476, 97791151005467 },{ 5, 25023068, 100858272665603 },{ 5, 25458094, 104021591529487 },{ 5, 25900683, 107284124726218 },{ 5, 26350967, 110648984014131 },{ 5, 26809078, 114119378748750 },{ 5, 27275154, 117698618943826 },{ 5, 27749333, 121390118428380 },{ 5, 28231755, 125197398102768 },{ 5, 28722564, 129124089296863 },{ 5, 29221906, 133173937233570 },{ 5, 29729929, 137350804600963 },{ 5, 30246783, 141658675236468 },{ 5, 30772624, 146101657926585 },{ 5, 31307606, 150683990325794 },{ 5, 31851889, 155410042998372 },{ 5, 32405634, 160284323586973 },{ 5, 32969006, 165311481111955 },{ 5, 33542172, 170496310405550 },{ 5, 34125303, 175843756685110 },{ 5, 34718571, 181358920269782 },{ 5, 35322153, 187047061445123 },{ 5, 35936229, 192913605480288 },{ 5, 36560980, 198964147802572 },{ 5, 37196593, 205204459334252 },{ 5, 37843256, 211640491996811 },{ 5, 38501161, 218278384387799 },{ 5, 39170503, 225124467635738 },{ 5, 39851483, 232185271438665 },{ 5, 40544301, 239467530292068 },{ 5, 41249163, 246978189912148 },{ 5, 41966280, 254724413860553 },{ 5, 42695864, 262713590376875 },{ 5, 43438131, 270953339425455 },{ 5, 44193303, 279451519963195 },{ 5, 44961604, 288216237435321 },{ 5, 45743261, 297255851506243 },{ 5, 46538508, 306578984032884 },{ 5, 47347580, 316194527288092 },{ 5, 48170718, 326111652441955 },{ 5, 49008166, 336339818309145 },{ 5, 49860173, 346888780370593 },{ 5, 50726992, 357768600078136 },{ 5, 51608880, 368989654450987 },{ 5, 52506101, 380562645973188 },{ 5, 53418919, 392498612801491 },{ 5, 54347607, 404808939293397 },{ 5, 55292440, 417505366865395 },{ 5, 56253700, 430600005191761 },{ 5, 57231670, 444105343754595 },{ 5, 58226643, 458034263756114 },{ 5, 59238913, 472400050404561 },{ 5, 60268781, 487216405585450 },{ 5, 61316554, 502497460930232 },{ 5, 62382543, 518257791294848 },{ 5, 63467063, 534512428661019 },{ 5, 64570438, 551276876473543 },{ 5, 65692995, 568567124427260 },{ 5, 66835068, 586399663717796 },{ 5, 67996995, 604791502770641 },{ 5, 69179123, 623760183463540 },{ 5, 70381802, 643323797857690 },{ 5, 71605390, 663501005453698 },{ 5, 72850250, 684311050988748 },{ 5, 74116751, 705773782791959 },{ 5, 75405271, 727909671715446 },{ 5, 76716192, 750739830659130 },{ 5, 78049903, 774286034707923 },{ 5, 79406800, 798570741900502 },{ 5, 80787287, 823617114649469 },{ 5, 82191774, 849449041833335 },{ 5, 83620678, 876091161581396 },{ 5, 85074424, 903568884773235 },{ 5, 86553443, 931908419275262 },{ 5, 88058174, 961136794937411 },{ 5, 89589066, 991281889373828 },{ 5, 91146572, 1022372454552149 },{ 5, 92731155, 1054438144216723 },{ 5, 94343286, 1087509542171936 },{ 5, 95983444, 1121618191452617 },{ 5, 97652116, 1156796624409337 },{ 5, 99349798, 1193078393737311 },{ 5, 101076994, 1230498104478488 },{ 5, 102834218, 1269091447027351 },{ 5, 104621991, 1308895231171917 },{ 5, 106440844, 1349947421202393 },{ 5, 108291318, 1392287172120985 },{ 5, 110173963, 1435954866987387 },{ 5, 112089337, 1480992155435580 },{ 5, 114038010, 1527441993398661 },{ 5, 116020561, 1575348684079616 },{ 5, 118037579, 1624757920207089 },{ 5, 120089662, 1675716827616464 },{ 5, 122177421, 1728274010197827 },{ 5, 124301475, 1782479596253672 },{ 5, 126462456, 1838385286310572 },{ 5, 128661006, 1896044402430416 },{ 5, 130897778, 1955511939068244 },{ 5, 133173436, 2016844615525180 },{ 5, 135488656, 2080100930046512 },{ 5, 137844126, 2145341215616491 },{ 5, 140240546, 2212627697503086 },{ 5, 142678628, 2282024552607573 },{ 5, 145159096, 2353597970675557 },{ 5, 147682687, 2427416217427825 },{ 5, 150250151, 2503549699671231 }};
    private static List<double> TurretLocationDmgDifferential = new List<double>
        { 1, 2, 5, 8, 11, 14, 18, 22, 27, 31, 36, 41, 46, 52, 58, 64, 70, 76, 82, 89, 96, 103, 110, 117, 125, 132, 140, 148, 156, 164, 172, 181, 189, 198, 207, 216, 225, 234, 243, 252, 262, 272, 281, 291, 301, 311, 322, 332, 343, 353 };//list of 50 doubles that are the multiples for each turret after the first
    private static List<double> TurretLocationCTUDifferential = new List<double>
        {1,2,3,5,6,8,10,12,13,15,17,19,21,23,25,27,29,32,34,36,38,40,43,45,47,49,52,54,56,59,61,63,66,68,71,73,76,78,81,83,86,88,91,93,96,98,101,104,106,109};//list of 50 ints that are the multiples for each turret after the first
    private static List<int> YardDifferentialList = new List<int>
        {1,16,32,64,128,256,512};
    private static List<int> YardPrestigeDifferentialList = new List<int>
        {30,60,120,240,480,960,1920,3840,7680,15360};
    public static int[,] buffs = new int[6, 3] 
    { { 1, 1, 1 }, { -1, 2, 1 }, { -1, 3, 1 }, { -1, 4, 1 }, { -1, 8, 1 }, { -1, 16, 1 } };
    public static int howManyYards;
    public static List<int> YardPrestigeList;


    /*public static myStats GetMyTurret(int location,int yard)
    {
        myStats myTurret = new myStats();
        myTurret.setLVL(Convert.ToInt32(yards[yard][location, 0]));
        myTurret.setROF(Convert.ToInt32(yards[yard][location, 1]));
        myTurret.setSTR(Convert.ToInt32(yards[yard][location, 2]));
        myTurret.setCTU(Convert.ToInt32(yards[yard][location, 3]));
        return myTurret;
    }*/
    public static void LoadSaveTurrets(string SaveDataString)
    {
        bool catchFound = false;
        string[] subOfSaveTurrets = SaveDataString.Split('|');
        for (int i = 0; i > subOfSaveTurrets.Length; i++)
        {
            if (subOfSaveTurrets[i] != " ")
            {
                if (catchFound == false)
                {
                    Int64[,] tempArr = defaultstart;
                    int iCount = 0;
                    string subset = subOfSaveTurrets[i];
                    while (subset.IndexOf('.') > 0)
                    {
                        tempArr[iCount, 0] = Convert.ToInt64(subset.Substring(0, subset.IndexOf('.')));
                        subset.Remove(0, subset.IndexOf('.') + 1);
                    }
                }
                else
                {
                    //-----------------------------------------------------------------------FUTURE SAVE DATA-----------------------------------------------------------------------------------------------------
                }
            }
            else catchFound = true;
        }
        HandleTurretLoad();
    }
    public static string SaveSenderTurrets()
    {
        string Save = "";
        for (int i = 0; i > yards.Count; i++)
        {
            Int64[,] tempArr = yards[i];
            Save += tempArr.ToString();
            Save += "|";
        }
        Save += " |";
        Save += YardPrestigeList.ToString();
        return Save;
    }
    public static void Starter()//Generates first and/or additional yards.
    {
        if (yards.Count == 0)
        {
            YardPrestigeList.Add(0);
            //starts the default game and the first turret
            yards.Add(defaultstart);
            Int64[,] currentyard = yards[0];
            currentyard[0, 1] = turrets[0, 0];
            currentyard[0, 2] = turrets[0, 1];
            currentyard[0, 3] = turrets[0, 2];
            yards[0] = currentyard;
        }
        else
        {
            YardPrestigeList.Add(0);
            //starts all of the yards from this point on when unlocked
            yards.Add(defaultstart);
            Int64[,] currentyard = yards[yards.Count];
            currentyard[0, 1] = yards.Count * turrets[0, 0];
            currentyard[0, 2] = yards.Count * turrets[0, 1];
            currentyard[0, 3] = yards.Count * turrets[0, 2];
            yards[yards.Count] = currentyard;
        }
    }
    public static void HandleTurretLoad()
    {
        howManyYards = yards.Count;
        for (int i = 0; i < howManyYards; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Int64 tempLevel = yards[i][j, 0];
                yards[i][j, 1] = Convert.ToInt64(turrets[tempLevel, 0]);//ROF
                yards[i][j, 2] = Convert.ToInt64(turrets[tempLevel, 1] * YardDifferentialList[i] * TurretLocationDmgDifferential[j] * YardPrestigeDifferentialList[YardPrestigeList[i]]);//Damage
                yards[i][j, 3] = Convert.ToInt64(turrets[tempLevel, 1] * YardDifferentialList[i] * TurretLocationCTUDifferential[j] * YardPrestigeDifferentialList[YardPrestigeList[i]]);//CTU
            }
        }
    }
    public static List<Int64> TurretStats(int yard, int location)//sends a list of the current turrets stats, Assign turret loc in monob turret script
    {
        Int64[,] currentyard = yards[yard];
        List<Int64> templist = new List<Int64>();
        templist.Add(currentyard[location, 0]);
        templist.Add(currentyard[location, 1]);
        templist.Add(currentyard[location, 2]);
        templist.Add(currentyard[location, 3]);
        return (templist);
    }
    public static List<Int64> HandleNewTurret(int yard, int location)
    {
        //takes the yard that you are building a turret and places a level one
        Int64[,] currentyard = yards[yard];
        currentyard[location, 0] = 1;
        //add currency drop =
        yards[yard] = currentyard;
        HandleTurretLoad();
        return (TurretStats(yard, location));
    }
    public static void HandleLevelUP(int yard, int location)//levelup a turret
    {
        Int64[,] currentyard = yards[yard];
        Int64 level = currentyard[location, 0];
        Int64 CTU = currentyard[location, 3];
        //add currency drop -=CTU
        level += 1;
        currentyard[location, 0] = level;
        currentyard[location, 1] = turrets[level, 0];
        currentyard[location, 2] = turrets[level, 1];
        currentyard[location, 3] = turrets[level, 2];
        yards[yard] = currentyard;
    }
}
