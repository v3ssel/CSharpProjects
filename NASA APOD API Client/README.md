# NASA APOD Api Client

Get API-Key at - [NASA API](https://api.nasa.gov/)

And place it in `appsettings.json`

### Input parameters

|Argument|Type|Description|
|---|---|---|
| ResultCount |int | The number of elements to output |

### Configuration Parameters

|Argument|Type|Description|
|---|---|---|
| ApiKey |string | API key |


### Examples of launching an application from the project folder

```
{
   "ApiKey": "API_KEY"
}

$dotnet run apod 5
19/01/2018
'Clouds in the LMC' by Josep Drudis
An alluring sight in southern skies, the Large Magellanic Cloud (LMC) is seen in this deep and detailed telescopic mosaic. Recorded with broadband and narrowband filters, the scene spans some 5 degrees or 10 full moons. The narrowba
nd filters are designed to transmit only light emitted by hydrogen, and oxygen atoms. Ionized by energetic starlight, the atoms emit their characteristic light as electrons are recaptured and the atoms transition to a lower energy s
tate. As a result, in this image the LMC seems covered with its own clouds of ionized gas surrounding its massive, young stars. Sculpted by the strong stellar winds and ultraviolet radiation, the glowing clouds, dominated by emissio
n from hydrogen, are known as H II (ionized hydrogen) regions. Itself composed of many overlapping H II regions, the Tarantula Nebula is the large star forming region at the left. The largest satellite of our Milky Way Galaxy, the L
MC is about 15,000 light-years across and lies a mere 160,000 light-years away toward the constellation Dorado.
https://apod.nasa.gov/apod/image/1801/LMC_RGBNB-Don-Josep5-Cc1024.jpg

04/04/2008
'Layers in Aureum Chaos'
At first glance these undulating shapes in shades of blue might look like waves on an ocean. Seen here in a false-color image from the Mars Reconnaissance Orbiter's HiRISE camera, they are actually layered rock outcrops found in Aur
eum Chaos. The larger Aureum Chaos region is a chaotic jumble of eroded terrain in the eastern part of Mars' immense canyon Valles Marineris. Distinct layers composing these outcrops could have been laid down by dust or volcanic ash
 settling from the atmosphere, sand carried by martian winds, or sediments deposited on the floor of an ancient lake. This close-up view of the otherwise red planet spans about 4 kilometers, a distance you might walk over flat groun
d in less than an hour.   digg_url = 'http://apod.nasa.gov/apod/ap080404.html'; digg_skin = 'compact';
https://apod.nasa.gov/apod/image/0804/PSP_007006_1765_e800.jpg

31/10/2010
'Halloween and the Ghost Head Nebula'
Halloween's origin is ancient and astronomical.  Since the fifth century BC, Halloween has been celebrated as a cross-quarter day, a day halfway between an equinox (equal day / equal night) and a solstice (minimum day / maximum nigh
t in the northern hemisphere).  With a modern calendar, however, the real cross-quarter day will occur next week.  Another cross-quarter day is Groundhog's Day. Halloween's modern celebration retains historic roots in dressing to sc
are away the spirits of the dead.  Perhaps a fitting tribute to this ancient holiday is this view of the Ghost Head Nebula taken with the Hubble Space Telescope.  Similar to the icon of a fictional ghost, NGC 2080 is actually a star
 forming region in the Large Magellanic Cloud, a satellite galaxy of our own Milky Way Galaxy.  The Ghost Head Nebula spans about 50 light-years and is shown in representative colors.
https://apod.nasa.gov/apod/image/1010/ngc2080_hst.jpg

15/01/1997
'Black Holes Signature From Advective Disks
Research Credit:'
 star. perhaps brighter than allowable from an ADAF onto a neutronservationsws (ADAFs).
https://apod.nasa.gov/apod/image/9701/xraybin_heasarc.gif

13/02/2007
'Vela Supernova Remnant in Visible Light'
The explosion is over but the consequences continue.  About eleven thousand years ago a star in the constellation of Vela could be seen to explode, creating a strange point of light briefly visible to humans living near the beginnin
g of recorded history.  The outer layers of the star crashed into the interstellar medium, driving a shock wave that is still visible today.  A roughly spherical, expanding shock wave is visible in X-rays. The above image captures m
uch of that filamentary and gigantic shock in visible light, spanning almost 100 light years and appearing twenty times the diameter of the full moon. As gas flies away from the detonated star, it decays and reacts with the interste
llar medium, producing light in many different colors and energy bands. Remaining at the center of the Vela Supernova Remnant is a pulsar, a star as dense as nuclear matter that completely rotates more than ten times in a single sec
ond.
https://apod.nasa.gov/apod/image/0702/vela_skyfactory.jpg

```
