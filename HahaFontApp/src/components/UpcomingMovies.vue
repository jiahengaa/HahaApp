<template>
  <div class="container" v-loading="loading"  element-loading-text="精彩值得等待..." element-loading-spinner="el-icon-loading" element-loading-background="rgba(0, 0, 0, 0)">
    <el-carousel :interval="400000" type="card" height="282px">
      <el-carousel-item  v-for="(movie,index) in results" :key="index" v-if="index<5">
        <!-- <img class="imgstyle" :src= movie.poster_path @click="filmClick(movie)"> -->
        <el-popover
            placement="bottom"
            width="500"
            trigger="hover">
             <!-- <el-button slot="reference">content</el-button> -->
             <div class="fileHoveInfo">
               <div class="fileHoveInfoTitle">{{movie.title}}</div>
               <img class="imgstyle" :src= movie.backdrop_path>
               <div class="filmText">{{movie.overview}}</div>
             </div>
             
             <img slot="reference" class="imgstyle" :src= movie.poster_path @click="filmClick(movie)">
          </el-popover>
      </el-carousel-item>
    </el-carousel>
    <div class="cards">
      <el-card shadow="hover" class="card"  v-for="(movie,index) in results" :key="index" v-if="index>5">
        <div class="filmTitle">{{movie.title}}</div>
          <el-popover
            placement="right"
            width="500"
            trigger="hover">
             <!-- <el-button slot="reference">content</el-button> -->
             <div class="fileHoveInfo">
               <div class="fileHoveInfoTitle">{{movie.title}}</div>
               <img class="imgstyle" :src= movie.backdrop_path>
               <div class="filmText">{{movie.overview}}</div>
             </div>
             
             <img slot="reference" class="imgstyle" :src= movie.poster_path @click="filmClick(movie)">
          </el-popover>
      </el-card>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import MoviePage from "../typings/MoviePage";
import Datetime from "../typings/Datetime";
import Movie from "../typings/Movie";

@Component({
  props: {
    moviePage: {}
  }
})
export default class UpcomingMovies extends Vue {
  dates: Datetime = {
    maximum: "",
    minimum: ""
  };
  page: number = 0;
  total_pages: number = 0;
  total_results: number = 0;
  results: any = [];
  loading: boolean = true;
  created() {
    window.UpcomingMoviesActions.getUpcomingMovies();
  }

  // 计算属性
  get computedMsg() {
    return "computed " + this.$props.propMessage;
  }

  mounted() {
    this.$nextTick(function() {
      this.$root.$data.eventHub.$on("upcomingMovies", (data: any) => {
        this.updateTreeData(data.movies);
      });
    });
  }

  beforeDestroy() {
    this.$root.$data.eventHub.$off("upcomingMovies");
  }

  updateTreeData(moviePage: MoviePage) {
    console.log(moviePage.results);
    this.results = moviePage.results;
    this.loading = moviePage.loading;
  }

  filmClick(movie: Movie) {
    console.log(movie)
  }
}
</script>

<style lang="scss">
$containerBackgroundColor: rgb(116, 88, 88);

.el-popover{
  background: #000000;
}
.fileHoveInfoTitle{
  vertical-align: text-top;
  margin-bottom: 10px;
}

.container {
  background-color: $containerBackgroundColor;
  height: 100%;

  .el-carousel__mask {
    opacity: 0;
  }

  .cards {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    align-content: flex-start;

    .card {
      flex: 20%;
      box-sizing: border-box;
      margin: 10px;
      margin-top: 0px;
      background-color: peru;
      border-width: 0px;
      .el-card__body {
        padding: 20px;
        padding-top: 10px;
      }

      .filmTitle {
        vertical-align: text-top;
      }

      .imgstyle {
        margin-top: 10px;
        display: flex;
        justify-content: center;
        align-items: center;

        width: 100%;
        height: 100%;
      }

      .filmText {
        margin-top: 4px;
        padding-left: 45px;
        padding-right: 45px;
      }
    }
  }
}
</style>


