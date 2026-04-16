public class CarsAssemble {

    int idealNumberOfCarsPerHour = 221;

    public double productionRatePerHour(int speed) {
        if (speed >= 1 && speed <= 4) {
            return speed * idealNumberOfCarsPerHour;
        } else if (speed >= 5 && speed <= 8) {
            return speed * idealNumberOfCarsPerHour / 100. * 90;
        } else if (speed == 9) {
            return speed * idealNumberOfCarsPerHour / 100. * 80;
        } else if (speed == 10) {
            return speed * idealNumberOfCarsPerHour / 100. * 77;
        }
        return 0;
    }

    public int workingItemsPerMinute(int speed) {
        return (int) (productionRatePerHour(speed) / 60.);
    }
}
