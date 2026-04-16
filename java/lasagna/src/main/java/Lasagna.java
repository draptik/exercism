public class Lasagna {
    private final int requiredOvenTimeInMinutes = 40;

    public int expectedMinutesInOven() {
      return requiredOvenTimeInMinutes;
    }

    public int remainingMinutesInOven(int actualMinutes) {
      return requiredOvenTimeInMinutes - actualMinutes;
    }

    public int preparationTimeInMinutes(int numberOfLayers) {
      return numberOfLayers * 2;
    }

    public int totalTimeInMinutes(int numberOfLayers, int actualMinutes) {
      return preparationTimeInMinutes(numberOfLayers) + actualMinutes;
    }
}
