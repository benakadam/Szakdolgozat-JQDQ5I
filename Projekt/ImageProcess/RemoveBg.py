from rembg import remove
from PIL import Image

input_path = "..\\..\\..\\Pictures\\input.bmp"
output_path = "..\\..\\..\\Pictures\\cropped.png"

input = Image.open(input_path)
bgRemoved = remove(input)
bgRemoved.save(output_path)

output = bgRemoved.crop(bgRemoved.getbbox())
output.save(output_path)


