export default class HelperMethods {
  public uppercaseFirstLetter(text: string): string {
    console.log(text, 'text b4')
    let newTextArray: string[] = []

    text.split(' ').forEach((word) => {
      let placeHolderOfChars = [...word]
      placeHolderOfChars[0] = placeHolderOfChars[0].toUpperCase()
      newTextArray.push(placeHolderOfChars.join(''))
    })

    return newTextArray.join(' ')
  }
}
