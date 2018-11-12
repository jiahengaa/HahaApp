<template>
  <div class="container" v-loading="loading"  element-loading-text="精彩值得等待..." element-loading-spinner="el-icon-loading" element-loading-background="rgba(0, 0, 0, 0.8)">
    <div class="cards">
      <el-card class="card"  v-for="(actor,index) in results" :key="index">
        <div class="filmTitle">{{actor.name}}</div>
          <img class="imgstyle" :src= actor.profile_path>
      </el-card>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import ActorPage from "../typings/ActorPage";

@Component({
  props: {
    moviePage: {}
  }
})
export default class PopularActors extends Vue {
  page: number = 0;
  total_pages: number = 0;
  total_results: number = 0;
  results: any = [];
  loading: boolean = true;
  created() {
    window.PopularActorsActions.getPopularActors();
  }

  // 计算属性
  get computedMsg() {
    return "computed " + this.$props.propMessage;
  }

  mounted() {
    this.$nextTick(function() {
      this.$root.$data.eventHub.$on("popularActors", (data: any) => {
        this.updateTreeData(data);
      });
    });
  }

  beforeDestroy() {
    this.$root.$data.eventHub.$off("popularActors");
  }
  updateTreeData(actorPage: ActorPage) {
    this.page = actorPage.popularActors.page;
    this.total_pages = actorPage.popularActors.total_pages;
    this.total_results = actorPage.popularActors.total_results;
    this.results = actorPage.popularActors.results;
    console.log(this.results);
    this.loading = actorPage.loading;
  }
}
</script>

<style lang="scss">
$containerBackgroundColor: rgb(116, 88, 88);

.container {
  background-color: $containerBackgroundColor;
  height: 100%;

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
        height: 350px;
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


