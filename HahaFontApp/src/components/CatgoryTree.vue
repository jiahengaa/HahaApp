<template>
    <div class="catgory-tree-container">
      <el-tree :data="treeData" :props="defaultProps">
        <span class="custom-tree-node" slot-scope="{ node, data }">
          <span class="custom-tree-node-label">
            <span class="custom-tree-node-icon">
              <svg class="icon" aria-hidden="true">
                <use v-if="data.type === 1" xlink:href="#icon-icon-wenjianjia"></use>
                <use v-else v-bind:xlink:href="data.name | fileCategory"></use>
              </svg>
            </span>
            <span class="custom-tree-node-name" :title="node.label">{{ node.label }}</span>
          </span>
          <span>
            <span class="iconfont icon-xiazai tree-tool-btn" type="text" size="mini" title="添加" @click="add(node, data)"></span>
            <span class="iconfont icon-xiazai tree-tool-btn" type="text" size="mini" title="删除" @click="remove(node, data)"></span>
            <span class="iconfont icon-shanchu tree-tool-btn" type="text" size="mini" title="编辑" @click="() => edit(node, data)"></span>
          </span>
        </span>
      </el-tree>
    </div>
</template>
<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  props: {
    treeData: {
      type: Array,
      default() {
        return [];
      }
    }
  },
  filters: {
    fileCategory: function(value) {
      const iconMap = {
        image: "icon-icon-tupianwenjian",
        video: "icon-icon-shipinwenjian",
        audio: "icon-icon-yinpinwenjian",
        doc: "icon-icon-wordwenjian",
        txt: "icon-icon-textwenjian",
        excel: "icon-icon-excelwenjian",
        ppt: "icon-icon-pptwenjian",
        pdf: "icon-icon-PDFwenjian",
        zip: "icon-icon-yasuobao"
      };
      let type = "unknown";
      const typeMap = {
        image: ["gif", "jpg", "jpeg", "png", "bmp", "webp"],
        video: ["mp4", "m3u8", "rmvb", "avi", "swf", "3gp", "mkv", "flv"],
        audio: ["mp3", "wav", "wma", "ogg", "aac", "flac"],
        doc: ["doc", "docx"],
        txt: ["txt"],
        excel: ["xls", "xlsx"],
        pdf: ["pdf", "epub"],
        ppt: ["ppt", "pptx"],
        zip: ["zip", "rar", "7z"]
      };
      Object.keys(typeMap).forEach(_type => {
        const extensions = typeMap[_type];
        if (extensions.indexOf(value) > -1) {
          type = _type;
        }
      });
      const icon = iconMap[type] || "icon-icon-qitawenjian";
      return `#${icon}`;
    }
  }
})
export default class CatgoryTree extends Vue {
  defaultProps: Object = {
    children: "children",
    label: "name"
  };

  created() {
    // console.log(`created:${this.$props.treeData}`)
  }

  mounted() {
    console.log(this.$props.treeData);
  }

  add() {}

  remove() {}

  edit() {}
}
</script>


<style lang="scss">
.catgory-tree-container {
  padding: 16px 4px;
  .el-tree-node__content {
    height: 36px;
    line-height: 36px;

    .custom-tree-node-icon {
      svg {
        width: 18px;
        height: 18px;
        position: relative;
        top: 4px;
      }
    }
  }
}
</style>


