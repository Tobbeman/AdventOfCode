package main

import (
	"io/ioutil"
	"strconv"
	"strings"
)

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func reverseArray(array []int) {
	for i, j := 0, len(array)-1; i < j; i, j = i+1, j-1 {
		array[i], array[j] = array[j], array[i]
	}
}

func main() {
	dat, err := ioutil.ReadFile("input.txt")
	check(err)

	println("First: ", first(string(dat[:]), 256))
	println("Second: ", second(string(dat[:])))
}

func first(stream string, lenght int) int {
	array := make([]int, lenght)
	for i := 0; i < lenght; i++ {
		array[i] = i
	}

	index := 0
	values := strings.Split(stream, ",")
	for i := 0; i < len(values); i++ {
		b, err := strconv.Atoi(values[i])
		check(err)
		sub := array[index:b]
		reverseArray(sub)
		for j:= index; j<b; j++{
			array[j] = sub[]
		}
	}

	return 0
}
func second(line string) int {
	return 0
}
